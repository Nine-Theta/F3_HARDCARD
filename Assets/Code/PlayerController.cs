using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _walkSpeedMult = 5f;

    [SerializeField]
    private Vector2 _lookMult = Vector2.one;

    [SerializeField]
    private float _maxLookAngle = 50f;

    [SerializeField]
    private Camera _playerCam;

    [SerializeField]
    private Rigidbody _playerBody;

    private Vector2 _moveInput = Vector2.zero;
    private Vector2 _lookInput = Vector2.zero;
    private bool _isMouseLocked = false;

    private void Start()
    {

    }

    public void OnMove(InputAction.CallbackContext pContext)
    {
        if (pContext.started) //prevents event being called twice times
            return;

        _moveInput = pContext.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext pContext)
    {
        if (!pContext.started)
            return;
    }

    public void OnLook(InputAction.CallbackContext pContext)
    {
        if (pContext.started)
            return;

        _lookInput = pContext.ReadValue<Vector2>();
    }

    public void OnToggleMouseLock(InputAction.CallbackContext pContext)
    {
        if (!pContext.started) 
            return;

        if (_isMouseLocked)
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;

        _isMouseLocked = !_isMouseLocked;
    }

    private void FixedUpdate()
    {
        CamLook();
        Movement();
    }

    private void Movement()
    {
        _playerBody.AddRelativeForce(new Vector3(_moveInput.x, 0, _moveInput.y) * _walkSpeedMult, ForceMode.Force);
    }

    private void CamLook()
    {
        Vector3 rotation = Vector3.zero;
        rotation.y = _lookInput.x;

        _playerBody.AddTorque(rotation * _lookMult.x, ForceMode.Force);

        _playerCam.transform.localRotation *=  Quaternion.AngleAxis(_lookInput.y * _lookMult.y, Vector3.right);

        //Dislike this, shitty cam clamp
        if (_playerCam.transform.localRotation.eulerAngles.x > _maxLookAngle && _playerCam.transform.localRotation.eulerAngles.x < 180)
        {
            _playerCam.transform.localRotation = Quaternion.AngleAxis(_maxLookAngle, Vector3.right);
        }
        else if (_playerCam.transform.localRotation.eulerAngles.x < (360 - _maxLookAngle) && _playerCam.transform.localRotation.eulerAngles.x > 180)
        {
            _playerCam.transform.localRotation = Quaternion.AngleAxis(_maxLookAngle, -Vector3.right);
        }
    }
}
