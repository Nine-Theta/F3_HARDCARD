using System.Collections.Generic;
using UnityEngine;

public class PoolGuestSpawner : MonoBehaviour
{
    #region Private Variables
    [SerializeField] private GameObject PoolGuests;
    [SerializeField] private int PoolGuestCount;
    [SerializeField] private float PoolGuestSpacing = 0;
    [SerializeField] private Transform TopLeft;
    [SerializeField] private Transform TopRight;
    [SerializeField] private Transform BottomLeft;
    [SerializeField] private Transform BottomRight;
    private List<Vector3> poolSpawnLocations = new List<Vector3>();
    private Vector3 spawnLocation = Vector3.zero;
    #endregion

    #region Private Functions
    private void Start()
    {
        for (int i = 0; i < PoolGuestCount; i++)
        {
            bool validSpawnLocation = false;

            while (!validSpawnLocation)
            {
                spawnLocation = new Vector3(Random.Range(TopLeft.position.x, TopRight.position.x), 0, Random.Range(TopLeft.position.z, BottomRight.position.z));

                validSpawnLocation = true;
                foreach (Vector3 poolSpawnLocation in poolSpawnLocations)
                {
                    if (Vector3.Distance(spawnLocation, poolSpawnLocation) < PoolGuestSpacing)
                    {
                        validSpawnLocation = false;
                        break;
                    }
                }
            }
            Instantiate(PoolGuests, spawnLocation, Quaternion.identity);
            poolSpawnLocations.Add(spawnLocation);
        }
    }
    #endregion
}
