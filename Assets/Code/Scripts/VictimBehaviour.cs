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
    float heightFlown;

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
            heightFlown = transform.position.y;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag.Equals(Tags.T_Ground))
        {
            if(needsBuoy)
            {
                //Trigger death
            }
        }

        if(collision.transform.tag.Equals(Tags.T_Floaty))
        {
            //Do floaty things
        }
    }
}
