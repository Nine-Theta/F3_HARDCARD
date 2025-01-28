using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBehaviour : MonoBehaviour
{
    [SerializeField]
     public float MoveSpeed = 0.05f;

    [field: SerializeField]
    public VictimBehaviour CapturedVictim { get; private set; }

    [field: SerializeField]
    public bool HasVictim { get; private set; }

    private BubbleStrategyBase _strategy;

    [SerializeField]
    private List<BubbleStrategyBase> _allStrategies;

    private void Start()
    {
        if(_strategy == null)
        {
            int chosenStrategy = Random.Range(0, _allStrategies.Count);
            _strategy = _allStrategies[chosenStrategy];
        }
        _strategy.OnStart(this);
    }

    [Button]
    public void Pop()
    {
        CapturedVictim.Release();
        _strategy.OnPop(this);
    }

    public void Capture(VictimBehaviour pVictim)
    {
        CapturedVictim = pVictim;
        HasVictim = true;
        pVictim.Capture(this);
    }

    public void SetStrategy(BubbleStrategyBase pStrategy)
    {
        _strategy = pStrategy;
    }

    private void FixedUpdate()
    {
        _strategy.OnUpdate(this);
    }
}
