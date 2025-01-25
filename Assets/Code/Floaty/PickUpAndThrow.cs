using System;
using UnityEngine;

public class PickUpAndThrow : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform holdPoint;

    [SerializeField] float throwForce = 10f;        // Base throw force
    Vector3 throwDirection = new Vector3(0, 1, 0);

    private GameObject heldObject;        // Reference to the currently held object

    private Vector3 screenCenter = new Vector3(0.5f, 0.5f, 0);
    [SerializeField] float maxDistance = 20f;
    [SerializeField] LayerMask layerMask;

    [SerializeField] KeyCode interactionKey = KeyCode.E;

    [SerializeField] Camera cam;

    //[SerializeField] LaunchArchRender LaunchArchRender;
    [SerializeField] LineRenderer lr;
    private bool renderArch;

    void Update()
    {
        Vector3 rayOrigin = cam.ViewportToWorldPoint(screenCenter);

        Debug.DrawRay(rayOrigin, cam.transform.forward * 10, Color.yellow);

        if (Input.GetKeyDown(interactionKey)) // Pick up or drop the object
        {
            if (heldObject == null)
                TryPickup();
            else
                DropObject();
        }

        if (Input.GetMouseButtonUp(0) && heldObject != null) // Throw the object
        {
            ThrowObject();
            renderArch = false;
            lr.enabled = false;
        }

        if (Input.GetMouseButton(0) && heldObject != null)
        {
            Debug.Log("Rendering arch");
            lr.enabled = true;
            renderArch = true;
        }

        if (renderArch)
        {
            CalculateArch();
        }
    }

    void CalculateArch()
    {
        Vector3 velocity = (cam.transform.forward).normalized * throwForce;

        ShowTrajectory(holdPoint.position + holdPoint.forward, velocity);
    }

    private void ShowTrajectory(Vector3 origin, Vector3 velocity)
    {
        Vector3[] points = new Vector3[100];
        lr.positionCount = points.Length;

        for (int i = 0; i < points.Length; i++)
        {
            float t = i * 0.1f;
            points[i] = origin + velocity * t + 0.5f * Physics.gravity * t * t;
        }

        lr.SetPositions(points);
    }

    void TryPickup()
    {

        Vector3 rayOrigin = cam.ViewportToWorldPoint(screenCenter);

        //Debug.Log("PickUp tied");
        //Ray ray = Camera.main.ViewportPointToRay(screenCenter);

        RaycastHit hit;

        Debug.DrawRay(rayOrigin, rayOrigin * 10, Color.yellow);

        if (Physics.Raycast(rayOrigin, cam.transform.forward, out hit, maxDistance, layerMask))
        {
            //Debug.Log("Ray send");
            if (hit.transform.tag.Equals(Tags.T_Floaty))
            {
                heldObject = hit.collider.gameObject;
                heldObject.GetComponent<Rigidbody>().isKinematic = true; // Disable physics
                heldObject.transform.position = holdPoint.position;     // Move to hold point
                heldObject.transform.parent = holdPoint;               // Parent to hold point
                
                Bus.Sync.Publish(this, new BuoyPicked());
            }
        }
        // Raycast to detect object in front of the player

    }

    void DropObject()
    {
        heldObject.GetComponent<Rigidbody>().isKinematic = false; // Enable physics
        heldObject.transform.parent = null;                      // Unparent
        heldObject = null;                                       // Clear reference
    }

    void ThrowObject()
    {
        StartCoroutine(heldObject.GetComponent<SelfDestruct>().Countdown());
        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        rb.isKinematic = false;                       // Enable physics
        heldObject.transform.parent = null;           // Unparent
        Vector3 forceToAdd = cam.transform.forward * throwForce;      // Throw in the player's look direction
        rb.AddForce(forceToAdd, ForceMode.Impulse);
        heldObject = null;                            // Clear reference
    }
}
