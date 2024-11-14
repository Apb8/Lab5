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
        GameObject treasure = GameObject.Find("Treasure");
        treasure.GetComponent<Renderer>().enabled = false; // Ocultar el tesoro
        return TaskStatus.COMPLETED;
    }
}
