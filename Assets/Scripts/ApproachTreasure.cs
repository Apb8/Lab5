using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using Pada1.BBCore.Framework;
using UnityEngine.AI;

[Action("MyActions/ApproachTreasure")]
[Help("Makes the robber approach the treasure.")]
public class ApproachTreasure : BasePrimitiveAction
{
    private NavMeshAgent agent;
    private GameObject treasure;

    // Distancia mínima para considerar que el ladrón está "cerca" del tesoro
    private const float closeDistance = 1.5f;

    public override void OnStart()
    {
        GameObject robber = GameObject.Find("Robber");
        agent = robber.GetComponent<NavMeshAgent>();
        treasure = GameObject.Find("Treasure");

        if (agent != null && treasure != null)
        {
            agent.SetDestination(treasure.transform.position);
            Debug.Log("Robber approaching treasure at position: " + treasure.transform.position);
        }
        else
        {
            Debug.LogError("Agent or Treasure not found.");
        }
    }

    public override TaskStatus OnUpdate()
    {
        if (agent == null || treasure == null)
        {
            return TaskStatus.FAILED;
        }

        // Asegura que el agente haya calculado la ruta y esté en movimiento
        if (agent.pathPending)
        {
            return TaskStatus.RUNNING; // Espera hasta que la ruta esté calculada
        }

        // Calcula la distancia manualmente para asegurarte de que esté cerca
        float distanceToTreasure = Vector3.Distance(agent.transform.position, treasure.transform.position);

        // Verifica si está dentro de la distancia mínima
        if (distanceToTreasure <= closeDistance)
        {
            Debug.Log("Robber has reached close proximity to the treasure.");
            return TaskStatus.COMPLETED; // Solo pasa a StealTreasure cuando está realmente cerca
        }

        return TaskStatus.RUNNING; // Sigue en el estado Approaching
    }
}
