using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using Pada1.BBCore.Framework;
using UnityEngine.AI;

[Action("MyActions/Wander")]
[Help("Makes the robber wander randomly.")]
public class Wander : BasePrimitiveAction
{
    public override TaskStatus OnUpdate()
    {
        // Implementación similar a la función WanderMov en la FSM original
        GameObject robber = GameObject.Find("Robber");
        NavMeshAgent agent = robber.GetComponent<NavMeshAgent>();

        Vector3 wanderPos = robber.transform.position + Random.insideUnitSphere * 10.0f;
        agent.SetDestination(wanderPos);

        return TaskStatus.COMPLETED;
    }
}
