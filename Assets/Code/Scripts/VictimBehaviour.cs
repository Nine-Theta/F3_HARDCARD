using NaughtyAttributes;
using System;
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

    [SerializeField] float heightForBuoy = 20f;
    [SerializeField] bool needsBuoy;
    [SerializeField] Transform buoyPosition;
    float heightFlown;
    Vector3 initialPos = new Vector3();

    private void OnEnable()
    {
        Bus.Sync.Subscribe<BubbleShot>(FreeFallCheck);
    }


    private void OnDisable()
    {
        Bus.Sync.Unsubscribe<BubbleShot>(FreeFallCheck);
    }
    private void FreeFallCheck(BubbleShot shot)
    {
        if (heightFlown >= heightForBuoy)
        {
            needsBuoy = true;
        }
    }
    private void Start()
    {
        _body = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        initialPos = this.transform.position;
    }

    [Button]
    public void Release()
    {
        _body.useGravity = true;
        _body.isKinematic = false;
        //_collider.isTrigger = false;

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
        if (_capturer != null && IsCaptured)
        {
            transform.position = _capturer.transform.position;
            heightFlown = transform.position.y;
        }
    }
    void Hitwater()
    {
        _body.useGravity = false;
        this.transform.position = initialPos;
        _body.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag.Equals(Tags.T_Ground))
        {
            Hitwater();
            Debug.Log("Hit water");
            if(needsBuoy)
            {
                //Trigger death
            }
        }

        if(other.transform.tag.Equals(Tags.T_Floaty))
        {
            other.transform.parent = buoyPosition;
            other.transform.localPosition = new Vector3();
        }
    }
}
