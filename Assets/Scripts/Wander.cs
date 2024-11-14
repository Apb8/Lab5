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
        GameObject robber = GameObject.Find("Robber");
        agent = robber.GetComponent<NavMeshAgent>();

        //pos aleatoria en el NavMesh
        wanderPos = robber.transform.position + Random.insideUnitSphere * 10.0f;
        wanderPos.y = robber.transform.position.y;
        agent.SetDestination(wanderPos);

        Debug.Log("Robber starts wandering to: " + wanderPos);
    }

    public override TaskStatus OnUpdate()
    {        
        if (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
        {
            return TaskStatus.RUNNING;
        }

        Debug.Log("Robber has reached wander position.");
        return TaskStatus.COMPLETED;
    }
}
