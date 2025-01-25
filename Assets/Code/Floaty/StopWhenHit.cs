using UnityEngine;

public class StopWhenHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals(Tags.T_Ground))
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.zero;    // Stop movement
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
            this.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }
}
