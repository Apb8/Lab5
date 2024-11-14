using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using Pada1.BBCore.Framework;
using UnityEngine.AI;

[Action("MyActions/MoveToPosition")]
[Help("Moves the cop to the target position.")]
public class MoveToPosition : BasePrimitiveAction
{
    [InParam("targetPosition")]
    public Vector3 targetPosition; // Posición objetivo pasada por `GetRandomInArea`

    private NavMeshAgent agent;

    public override void OnStart()
    {
        GameObject cop = GameObject.Find("Cop");
        agent = cop.GetComponent<NavMeshAgent>();

        if (agent != null)
        {
            agent.SetDestination(targetPosition);
            Debug.Log("Cop moving to: " + targetPosition);
        }
    }

    public override TaskStatus OnUpdate()
    {
        if (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
        {
            return TaskStatus.RUNNING; // Sigue moviéndose
        }

        Debug.Log("Cop has reached the target position.");
        return TaskStatus.COMPLETED; // Llegó a destino
    }
}
