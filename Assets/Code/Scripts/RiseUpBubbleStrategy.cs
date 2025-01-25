using UnityEngine;

[CreateAssetMenu(fileName = "RiseUpBubbleStrategy", menuName = "ScriptableObjects/BubbleStrategies/RiseUpBubbleStrategy")]
public class RiseUpBubbleStrategy : BubbleStrategyBase
{
    public override void OnUpdate()
    {
        if (Bubble.HasVictim)
        {
            Bubble.transform.position += Vector3.up * Bubble.MoveSpeed;
        }
    }
}
