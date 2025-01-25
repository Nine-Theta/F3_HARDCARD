using System.Collections;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float timeToSelfDestruct = 20f;

    public IEnumerator Countdown()
    {
        Debug.Log("Countdown started");
        yield return new WaitForSeconds(timeToSelfDestruct);
        Destroy(gameObject);
    }


}
