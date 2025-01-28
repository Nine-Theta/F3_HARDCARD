using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;

    private Vector3 _direction;
    private bool _isFired = false;

    public void Fire(Vector3 pDirection)
    {
        _direction = pDirection;
        _isFired = true;
        StartCoroutine(gameObject.GetComponent<SelfDestruct>().Countdown());
        //transform.rotation = Quaternion.LookRotation(pDirection);
    }

    private void FixedUpdate()
    {
        if (_isFired)
            transform.position += _direction * _moveSpeed;
    }

    private void OnTriggerEnter(Collider pOther)
    {
        Destroy(gameObject);
    }
}
