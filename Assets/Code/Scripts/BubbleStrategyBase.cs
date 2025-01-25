using UnityEngine;

public abstract class BubbleStrategyBase : ScriptableObject
{
    protected BubbleBehaviour Bubble;

    public virtual void OnStart(BubbleBehaviour pBehaviour)
    {
        Bubble = pBehaviour;
    }

    public abstract void OnUpdate();

    public virtual void OnPop()
    {
        Destroy(Bubble.gameObject);
    }
}
