using UnityEngine;

public class FrontFacing : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        this.transform.LookAt(mainCamera.transform.position);
    }
}
