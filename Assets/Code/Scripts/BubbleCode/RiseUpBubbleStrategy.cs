using UnityEngine;

[CreateAssetMenu(fileName = "RiseUpBubbleStrategy", menuName = "ScriptableObjects/BubbleStrategies/RiseUp")]
public class RiseUpBubbleStrategy : BubbleStrategyBase
{
    public override void OnUpdate(BubbleBehaviour pBehaviour)
    {
        if (pBehaviour != null && pBehaviour.HasVictim)
        {
            pBehaviour.transform.position += Vector3.up * pBehaviour.MoveSpeed;
        }
    }
}
