using UnityEngine;

public class HumanReachesTop : MonoBehaviour
{
    [SerializeField] LifeCounter lifeCounter;
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag.Equals(Tags.T_Victim))
        {
            lifeCounter.UpdateCounter();
        }
    }
}
