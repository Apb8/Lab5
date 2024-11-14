using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using Pada1.BBCore.Framework;
using UnityEngine.AI;

[Action("MyActions/Wander")]
[Help("Makes the robber wander randomly.")]
public class Wander : BasePrimitiveAction
{
    private NavMeshAgent agent;
    private Vector3 wanderPos;

    public override void OnStart()
    {
        // Solo se ejecuta al inicio de Wander
        GameObject robber = GameObject.Find("Robber");
        agent = robber.GetComponent<NavMeshAgent>();

        // Genera una posición aleatoria en el NavMesh
        wanderPos = robber.transform.position + Random.insideUnitSphere * 10.0f;
        wanderPos.y = robber.transform.position.y; // Mantiene la misma altura
        agent.SetDestination(wanderPos);

        Debug.Log("Robber starts wandering to: " + wanderPos);
    }

    public override TaskStatus OnUpdate()
    {
        // Verifica si ha llegado al destino
        if (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
        {
            return TaskStatus.RUNNING; // Aún no ha llegado
        }

        Debug.Log("Robber has reached wander position.");
        return TaskStatus.COMPLETED; // Ha llegado a destino
    }
}
