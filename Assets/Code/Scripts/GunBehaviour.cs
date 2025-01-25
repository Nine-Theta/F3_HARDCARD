using NaughtyAttributes;
using System.Collections;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _maxShootingRange = 50f;

    [SerializeField]
    private LayerMask _shootingLayer;

    [SerializeField]
    private bool _isHolstered = false;

    [SerializeField]
    private Camera _playerCam;

    [SerializeField]
    private BulletBehaviour _bullet;

    [SerializeField]
    private Transform _bulletSpawnpoint;

    [SerializeField]
    private GameObject _gunVisual;

    public void FireGun()
    {
        if (_isHolstered)
            return;

        Ray ray = _playerCam.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        Debug.DrawRay(_playerCam.transform.position, ray.direction * _maxShootingRange, Color.red, 2f);

        Instantiate(_bullet, _bulletSpawnpoint.position, Quaternion.LookRotation(_bulletSpawnpoint.forward)).Fire(_bulletSpawnpoint.forward);

        RaycastHit[] hits = Physics.RaycastAll(ray, _maxShootingRange, _shootingLayer.value);

        foreach (RaycastHit hit in hits)
        {
            //Debug.Log("I hit " + hit.transform.name);

            if (hit.transform.tag == "Bubble")
            {
                hit.transform.GetComponent<BubbleBehaviour>().Pop();
                Bus.Sync.Publish(this, new BubbleShot());
            }
        }
    }

    [Button]
    public void ToggleHolsterGun()
    {
        _gunVisual.SetActive(_isHolstered);
        _isHolstered = !_isHolstered;
    }
}
