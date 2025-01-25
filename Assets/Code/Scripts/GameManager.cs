using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Private Variables
    [SerializeField] private List<GameObject> PoolGuests;
    [SerializeField] private GameObject Bubble;
    [SerializeField] private int PoolGuestCount;
    [SerializeField] private float PoolGuestSpacing = 0;
    private PoolGuestSpawner poolGuestSpawner;
    private List<GameObject> GuestsInPool = new List<GameObject>();
    #endregion

    #region Singleton
    private static GameManager instance;

    private void Awake()
    {
        instance = this;

        if (instance != null && instance != this)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }
    #endregion

    #region Private Functions
    private IEnumerator Start()
    {
        yield return 1f;
        poolGuestSpawner = GetComponent<PoolGuestSpawner>();
        GuestsInPool = poolGuestSpawner.SpawnGuests(PoolGuests, PoolGuestCount, PoolGuestSpacing);
    }

    private void Update()
    {
        StartCoroutine(KidnapGuest());
    }

    private IEnumerator KidnapGuest()
    {
        yield return Random.Range(5, 20);

        // get random guest
        int randomIndex = Random.Range(0, GuestsInPool.Count);

        // Guest becomes bubbles (get component)
        // GameObject bubble = Instantiate(Bubble, GuestsInPool[randomIndex].transform.position, Quarternion.identity);
        // bubble.Capture(GuestsInPool[randomIndex]);
        //TODO: bubble -> trigger random bubble effect

        //Remove person from list while theyre floating
        //  GuestsInPool[randomIndex].remove();
    }
    #endregion
}
