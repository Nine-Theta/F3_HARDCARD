using UnityEngine;

public abstract class BubbleStrategyBase : ScriptableObject
{

    public virtual void OnStart(BubbleBehaviour pBehaviour)
    {

    }

    public abstract void OnUpdate(BubbleBehaviour pBehaviour);

    public virtual void OnPop(BubbleBehaviour pBehaviour)
    {
        Destroy(pBehaviour.gameObject);
    }
}
