using NaughtyAttributes;
using System.Text.RegularExpressions;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class VictimBehaviour : MonoBehaviour
{
    private Rigidbody _body;
    private Collider _collider;

    [field: SerializeField]
    public bool IsCaptured { get; private set; }

    [SerializeField]
    private BubbleBehaviour _capturer;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    [Button]
    public void Release()
    {
        _body.useGravity = true;
        _collider.isTrigger = false;

        IsCaptured = false;
        _capturer = null;
    }

    public void Capture(BubbleBehaviour pCapturer)
    {
        _body.useGravity = false;
        _collider.isTrigger = true;
        IsCaptured = true;
        _capturer = pCapturer;
    }

    private void LateUpdate()
    {
        if (IsCaptured)
        {
            transform.position = _capturer.transform.position;
        }
    }
}
