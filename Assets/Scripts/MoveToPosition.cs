using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using Pada1.BBCore.Framework;
using UnityEngine.AI;

[Action("MyActions/MoveToPositionn")]
[Help("Moves the cop to the target position using NavMeshAgent.")]
public class MoveToPosition : BasePrimitiveAction
{
    [InParam("targetPosition")]
    public Vector3 targetPosition;

    private NavMeshAgent agent;

    public override void OnStart()
    {
        GameObject cop = GameObject.Find("Cop");
        agent = cop.GetComponent<NavMeshAgent>();

        if (agent != null)
        {
            agent.SetDestination(targetPosition); 
            Debug.Log("Cop moving to position: " + targetPosition);
        }
        else
        {
            Debug.LogError("No NavMeshAgent found on Cop.");
        }
    }

    public override TaskStatus OnUpdate()
    {
        if (agent == null)
        {
            return TaskStatus.FAILED; 
        }
            
        if (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
        {
            return TaskStatus.RUNNING;
        }

        Debug.Log("Cop has reached the target position.");
        return TaskStatus.COMPLETED; 
    }
}
