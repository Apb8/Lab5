using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using Pada1.BBCore.Framework;
using UnityEngine.AI;

[Action("MyActions/Hide")]
[Help("Makes the robber hide.")]
public class Hide : BasePrimitiveAction
{
    public override TaskStatus OnUpdate()
    {
        GameObject robber = GameObject.Find("Robber");
        GameObject cop = GameObject.Find("Cop");
        NavMeshAgent agent = robber.GetComponent<NavMeshAgent>();

        Vector3 directionToCop = robber.transform.position - cop.transform.position;
        directionToCop.Normalize();

        RaycastHit hit;
        if (Physics.Raycast(robber.transform.position, directionToCop, out hit))
        {
            Vector3 hidePosition = hit.point + directionToCop * 2.0f;
            agent.SetDestination(hidePosition);
        }
        return TaskStatus.COMPLETED;
    }
}
