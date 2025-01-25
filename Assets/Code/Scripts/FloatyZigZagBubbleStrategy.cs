using UnityEngine;

[CreateAssetMenu(fileName = "FloatyZigZagBubbleStrategy", menuName="ScriptableObjects/BubbleStrategies/FloatyZigZag")]
public class FloatyZigZagBubbleStrategy : BubbleStrategyBase
{
    [SerializeField] private int maxSwing = 1;
    [SerializeField] private bool right = true;
    private int currentSwing = 0;
    private Vector3 movement = Vector3.zero;
    
    public override void OnUpdate()
    {
        if(Bubble.HasVictim)
        {
            if(right)
            {
                if(currentSwing != maxSwing)
                {
                    currentSwing++;
                    movement = new Vector3(0, 1, currentSwing);
                }
                else
                {
                    right = false;
                }
            }
            else
            {
                if (currentSwing != -maxSwing)
                {
                    currentSwing--;
                    movement = new Vector3(0, 1, currentSwing);
                }
                else
                {
                    right = true;
                }
            }

            Bubble.transform.position += movement * Bubble.MoveSpeed;
        }
    }
}
