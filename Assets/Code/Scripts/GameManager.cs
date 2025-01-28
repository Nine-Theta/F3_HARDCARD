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
    [SerializeField] private float KidnapAmount = 0;
    [SerializeField] private float minKidnapTimer = 2f;
    [SerializeField] private float maxKidnapTimer = 7f;
    private PoolGuestSpawner poolGuestSpawner;
    private List<GameObject> GuestsInPool = new List<GameObject>();
    private List<GameObject> KidnappedGuests = new List<GameObject>();
    private bool waiting = false;
    private int currentKidnappedAmount = 0;
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

        if(KidnapAmount > PoolGuestCount)
        {
            KidnapAmount = PoolGuestCount;
        }
    }

    private void Update()
    {
        if(!waiting)
        {
            waiting = true;
            StartCoroutine(KidnapGuest());
        }
    }

    private IEnumerator KidnapGuest()
    {
        if(currentKidnappedAmount < KidnapAmount)
        { 
            yield return new WaitForSeconds(Random.Range(minKidnapTimer, maxKidnapTimer));

            // get random guest
            int randomIndex = Random.Range(0, GuestsInPool.Count);
            GameObject newBubble = Instantiate(Bubble, GuestsInPool[randomIndex].transform.position, Quaternion.identity);
            newBubble.GetComponent<BubbleBehaviour>().Capture(GuestsInPool[randomIndex].GetComponent<VictimBehaviour>());
            KidnappedGuests.Add(GuestsInPool[randomIndex]);
            GuestsInPool.RemoveAt(randomIndex);
            waiting = false;
            currentKidnappedAmount++;
        }
    }
    #endregion
}
