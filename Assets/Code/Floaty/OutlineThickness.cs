using System;
using UnityEngine;

public class OutlineThickness : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField] float thickness = 0.03f;

    [SerializeField] GameObject arrow;
    private void OnEnable()
    {
        Bus.Sync.Subscribe<BubbleShot>(BubbleWasShot);
        Bus.Sync.Subscribe<BuoyPicked>(BuoyWasPicked);
    }


    private void OnDisable()
    {
        Bus.Sync.Unsubscribe<BubbleShot>(BubbleWasShot);
        Bus.Sync.Unsubscribe<BuoyPicked>(BuoyWasPicked);
    }

    private void BuoyWasPicked(BuoyPicked picked)
    {
        if (material!= null)
        {
            SetThickness(0); 
        }
        if (arrow != null)
        {
            arrow.SetActive(false);
        }
    }
    
    private void BubbleWasShot(BubbleShot shot)
    {
        
        if (material != null)
        {
            
            SetThickness(thickness);
        }
        if (arrow != null)
        {
            arrow.SetActive(true);
        }
    }

    public void SetThickness(float value)
    {
        Debug.Log("Changed thickness");
        material.SetFloat("_OutlineThic", value);
        Debug.Log(material.GetFloat("_OutlineThic"));
    }
}
