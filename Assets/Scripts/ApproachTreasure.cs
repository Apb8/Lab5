using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using Pada1.BBCore.Framework;
using UnityEngine.AI;

[Action("MyActions/ApproachTreasure")]
[Help("Makes the robber approach the treasure.")]
public class ApproachTreasure : BasePrimitiveAction
{
    public override TaskStatus OnUpdate()
    {
        GameObject robber = GameObject.Find("Robber");
        GameObject treasure = GameObject.Find("Treasure");
        NavMeshAgent agent = robber.GetComponent<NavMeshAgent>();

        agent.SetDestination(treasure.transform.position);
        return TaskStatus.COMPLETED;
    }
}
