using UnityEngine;

[CreateAssetMenu(fileName = "FloatyZigZagBubbleStrategy", menuName="ScriptableObjects/BubbleStrategies/FloatyZigZag")]
public class FloatyZigZagBubbleStrategy : BubbleStrategyBase
{
    [SerializeField] private int maxSwing = 1;
    private Vector3 movement = Vector3.zero;
    private int currentSwing = 0;
    
    public override void OnUpdate()
    {
        if(Bubble.HasVictim)
        {
            float swingValue = Mathf.Sin(Time.time) * maxSwing;

            movement = new Vector3(0, 1, swingValue);

            Bubble.transform.position += movement * Bubble.MoveSpeed;
        }
    }
}
