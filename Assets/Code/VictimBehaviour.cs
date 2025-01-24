using UnityEngine;

public class VictimBehaviour : MonoBehaviour
{
    private Rigidbody _body;
    private Collider _collider;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    public void Release()
    {
        _body.useGravity = true;
        _collider.isTrigger = false;
    }

    public void Capture()
    {
        _body.useGravity = false;
        _collider.isTrigger = true;
    }
}
