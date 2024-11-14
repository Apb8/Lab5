using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/IsCopNear")]
[Help("Checks whether the cop is near the treasure.")]
public class IsCopNear : ConditionBase
{
    public override bool Check()
    {
        GameObject cop = GameObject.Find("Cop");
        GameObject treasure = GameObject.Find("Treasure");
        return Vector3.Distance(cop.transform.position, treasure.transform.position) < 10f;
    }
}