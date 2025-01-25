using System.Collections.Generic;
using UnityEngine;

public class PoolGuestSpawner : MonoBehaviour
{
    #region Private Variables
    [SerializeField] private Transform TopLeft;
    [SerializeField] private Transform TopRight;
    [SerializeField] private Transform BottomLeft;
    [SerializeField] private Transform BottomRight;
    #endregion

    #region Private Functions
    public List<GameObject> SpawnGuests(List<GameObject> PoolGuests, int PoolGuestCount, float PoolGuestSpacing)
    {
        Vector3 spawnLocation = Vector3.zero;
        List<Vector3> GuestsInPoolLocation = new List<Vector3>();
        List<GameObject> GuestsInPool = new List<GameObject>();

        for (int i = 0; i < PoolGuestCount; i++)
        {
            bool validSpawnLocation = false;

            while (!validSpawnLocation)
            {
                spawnLocation = new Vector3(Random.Range(TopLeft.position.x, TopRight.position.x), 0, Random.Range(TopLeft.position.z, BottomRight.position.z));

                validSpawnLocation = true;
                foreach (Vector3 poolSpawnLocation in GuestsInPoolLocation)
                {
                    if (Vector3.Distance(spawnLocation, poolSpawnLocation) < PoolGuestSpacing)
                    {
                        validSpawnLocation = false;
                        break;
                    }
                }
            }
            int randomIndex = Random.Range(0, PoolGuests.Count);
            GameObject guest = Instantiate(PoolGuests[randomIndex], spawnLocation, Quaternion.identity);
            GuestsInPoolLocation.Add(spawnLocation);
            GuestsInPool.Add(guest);
        }
        return GuestsInPool;
    }
    #endregion
}
