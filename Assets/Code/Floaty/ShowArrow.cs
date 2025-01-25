using System;
using UnityEngine;

public class ShowArrow : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    private void OnEnable()
    {
        Bus.Sync.Subscribe<BubbleShot>(EnableArrow);
        Bus.Sync.Subscribe<BuoyPicked>(DisableArrow);
    }

    private void OnDisable()
    {
        Bus.Sync.Unsubscribe<BubbleShot>(EnableArrow);
        Bus.Sync.Unsubscribe<BuoyPicked>(DisableArrow);
    }

    void DisableArrow(BuoyPicked picked)
    {
        arrow.SetActive(false);
    }
    private void EnableArrow(BubbleShot shot)
    {
        arrow.SetActive(true);
    }
}
