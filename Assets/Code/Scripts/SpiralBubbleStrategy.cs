using UnityEngine;

[CreateAssetMenu(fileName = "SpiralBubbleStrategy", menuName = "ScriptableObjects/BubbleStrategies/Spiral")]
public class SpiralBubbleBehaviour : BubbleStrategyBase
{
    [SerializeField] private int maxRadius = 1;
    [SerializeField] private int angle = 0;
    private Vector3 movement = Vector3.zero;
    private Vector3 fixedPoint = Vector3.zero;
    private int currentSwing = 0;
    private float currentAngle = 0;
    public override void OnUpdate(BubbleBehaviour pBehaviour)
    {
        if(pBehaviour != null && pBehaviour.HasVictim)
        {
            fixedPoint = pBehaviour.CapturedVictim.transform.position;

            currentAngle = angle * Time.time;

            Vector3 offsetMovement = new Vector3(Mathf.Sin(currentAngle), 1, Mathf.Cos(currentAngle)) * maxRadius;

            pBehaviour.transform.position += offsetMovement * pBehaviour.MoveSpeed;
        }
    }
}
