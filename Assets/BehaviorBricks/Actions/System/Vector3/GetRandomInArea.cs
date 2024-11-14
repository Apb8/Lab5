using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;
using Pada1.BBCore.Framework;

namespace BBUnity.Actions
{
    /// <summary>
    /// It is an action to obtain a random position of an area.
    /// </summary>
    [Condition("MyConditions/IsCopNear")]
    [Help("Checks whether the cop is near the treasure.")]
    public class IsCopNear : ConditionBase
    {
        public override bool Check()
        {
            GameObject cop = GameObject.Find("Cop");
            GameObject treasure = GameObject.Find("Treasure");

            // Condición de proximidad (ajusta la distancia según tu juego)
            return Vector3.Distance(cop.transform.position, treasure.transform.position) < 10f;
        }
    }
}
