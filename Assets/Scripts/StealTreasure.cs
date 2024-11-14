using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using Pada1.BBCore.Framework;

[Action("MyActions/StealTreasure")]
[Help("Steals the treasure.")]
public class StealTreasure : BasePrimitiveAction
{
    public override TaskStatus OnUpdate()
    {
        GameObject robber = GameObject.Find("Robber");
        RobberState robberState = robber.GetComponent<RobberState>();

        if (robberState.hasStolenTreasure)
        {
            Debug.Log("Treasure has already been stolen.");
            return TaskStatus.COMPLETED;
        }

        GameObject treasure = GameObject.Find("Treasure");

        if (treasure != null)
        {
            treasure.GetComponent<Renderer>().enabled = false;
            robberState.hasStolenTreasure = true;
            Debug.Log("Treasure stolen!");
            return TaskStatus.COMPLETED;
        }
        else
        {
            Debug.LogError("Treasure object not found in the scene.");
            return TaskStatus.FAILED;
        }
    }
}


