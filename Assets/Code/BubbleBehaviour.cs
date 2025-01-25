using NaughtyAttributes;
using UnityEngine;

public class BubbleBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _floatSpeed = 0.05f;

    [SerializeField]
    private VictimBehaviour _capturedVictim;

    [SerializeField]
    private bool _hasVictim;

    [Button]
    public void Pop()
    {
        _capturedVictim.Release();
        Destroy(gameObject);
    }

    public void Capture(VictimBehaviour pVictim)
    {
        _capturedVictim = pVictim;
        pVictim.Capture(this);
    }

    private void FixedUpdate()
    {
        if (_hasVictim)
        {
            transform.position += Vector3.up * _floatSpeed;
        }
    }
}
