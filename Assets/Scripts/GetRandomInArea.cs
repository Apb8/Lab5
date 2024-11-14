using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using Pada1.BBCore.Framework;
using UnityEngine.AI;

[Action("MyActions/GetRandomInAreaa")]
[Help("Calculates a random position within a defined radius on the NavMesh.")]
public class GetRandomInArea : BasePrimitiveAction
{
    [OutParam("targetPosition")]
    public Vector3 targetPosition;

    [InParam("radius")]
    public float radius = 20.0f; // Aumenta el radio si es necesario

    public override TaskStatus OnUpdate()
    {
        GameObject cop = GameObject.Find("Cop");

        if (cop == null)
        {
            Debug.LogError("Cop object not found in the scene.");
            return TaskStatus.FAILED;
        }

        // Genera una dirección aleatoria dentro del radio en el plano XZ
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection.y = 0; // Mantener en el plano horizontal
        randomDirection += cop.transform.position;

        // Ajusta la posición generada a la altura del Cop
        randomDirection.y = cop.transform.position.y;

        // Buscar la posición válida en la NavMesh dentro del radio
        NavMeshHit navHit;
        if (NavMesh.SamplePosition(randomDirection, out navHit, radius, NavMesh.AllAreas))
        {
            targetPosition = navHit.position;
            Debug.Log("Random target position on NavMesh set to: " + targetPosition);
            return TaskStatus.COMPLETED;
        }

        Debug.LogError("Failed to find a valid NavMesh position within radius.");
        return TaskStatus.FAILED;
    }
}
