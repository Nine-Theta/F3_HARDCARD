using UnityEngine;

public class HumanReachesTop : MonoBehaviour
{
    [SerializeField] LifeCounter lifeCounter;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag.Equals(Tags.T_Victim))
        {
            lifeCounter.UpdateCounter();
        }
    }
}
