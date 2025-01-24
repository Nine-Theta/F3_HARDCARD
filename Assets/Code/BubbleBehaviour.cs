using UnityEngine;

public class BubbleBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _floatSpeed = 0.05f;

    [SerializeField]
    private VictimBehaviour _capturedVictim;

    [SerializeField]
    private bool _hasVictim;

    public void Pop()
    {
        _capturedVictim.Release();
    }

    private void FixedUpdate()
    {
        if (_hasVictim)
        {
            transform.position += Vector3.up * _floatSpeed;
        }
    }
}
