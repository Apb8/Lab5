using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using Pada1.BBCore.Framework;

[Action("MyActions/GetRandomInArea")]
[Help("Calculates a random position within a certain area for the cop.")]
public class GetRandomInArea : BasePrimitiveAction
{
    [OutParam("targetPosition")]
    public Vector3 targetPosition; // Variable de salida para la posición

    public override void OnStart()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 10.0f; // Tamaño del área
        randomDirection += GameObject.Find("Cop").transform.position; // Centrado en el Cop
        randomDirection.y = GameObject.Find("Cop").transform.position.y; // Mantener la altura

        targetPosition = randomDirection;
        Debug.Log("Random target position set to: " + targetPosition);
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.COMPLETED;
    }
}
