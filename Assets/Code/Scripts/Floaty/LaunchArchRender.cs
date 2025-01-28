using System;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class LaunchArchRender : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform cam;
    LineRenderer lr;

    public bool renderArch;

    float velocity;
    float angle;
    [SerializeField] int resolution = 0;
    float radianAngle;



    private void Awake()
    {
        lr = GetComponent<LineRenderer>();

        lr.positionCount = resolution + 1;
    }

    public void SetNeedsBasedOnThrow(Vector3 direction, float throwForce, int _resolution)
    {
        velocity = throwForce; // Use the throw force as the velocity
        angle = Vector3.Angle(Vector3.forward, direction); // Angle of the throw
        radianAngle = Mathf.Deg2Rad * angle; // Convert angle to radians

        resolution = _resolution;
    }

    private void Update()
    {
        if(renderArch)
        {
            RenderArch();
        }
    }
    void RenderArch()
    {
        lr.SetPositions(CalculateArchArray());
    }

    private Vector3[] CalculateArchArray()
    {
        Vector3[] arcArray = new Vector3[resolution + 1];

        float timeOfFlight = (2 * velocity * Mathf.Sin(radianAngle)) / Mathf.Abs(Physics.gravity.y);
        float maxDistance = velocity * Mathf.Cos(radianAngle) * timeOfFlight;

        for (int i = 0; i <= resolution; i++)
        {
            float t = i / (float)resolution * timeOfFlight;
            arcArray[i] = CalculateArchPoint(t);
        }

        return arcArray;
    }

    private Vector3 CalculateArchPoint(float t)
    {

        float horizontalDistance = velocity * Mathf.Cos(radianAngle) * t;
        Vector3 forward = new Vector3(player.transform.forward.x, 0, player.transform.forward.z).normalized;
        Vector3 horizontalOffset = forward * horizontalDistance;

        // Vertical position
        float y = (velocity * Mathf.Sin(radianAngle) * t) - (0.5f * Mathf.Abs(Physics.gravity.y) * t * t);

            // Combine horizontal and vertical
            return player.position + horizontalOffset + new Vector3(0, y, 0);
    }
    /*private Vector3[] CalculateArchArray()
    {
        Vector3[] arcArray = new Vector3[resolution + 1];

        radianAngle = Mathf.Deg2Rad * angle;
        float maxDistance = (float)(velocity * velocity * Math.Sin(2 * radianAngle)) / Physics.gravity.y;

        for (int i = 0; i <= resolution; i++)
        {
            float t = i / resolution;
            arcArray[i] = CalculateArchPoint(t, maxDistance);
        }

        return arcArray;
    }

    private Vector3 CalculateArchPoint(float t, float maxDistance)
    {
        float x = t * maxDistance;
        float y = (float)(x * Math.Tan(radianAngle) - ((Physics.gravity.y * x * x) / (2 * velocity * velocity * Math.Cos(radianAngle) * Math.Cos(radianAngle))));

        return new Vector3(x, y);
    }*/
}
