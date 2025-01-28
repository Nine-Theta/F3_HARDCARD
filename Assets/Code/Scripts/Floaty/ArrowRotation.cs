using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
    void FixedUpdate()
    {
        this.transform.LookAt(Camera.main.transform);
        //this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y + 90, this.transform.rotation.z);
    }
}
