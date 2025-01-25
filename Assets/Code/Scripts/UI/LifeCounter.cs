using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class LifeCounter : MonoBehaviour
{
    [SerializeField] int numberOfLifes = 3;

    [SerializeField] TMP_Text textBox;

    public void UpdateCounter()
    {
        numberOfLifes--;
        textBox.text = numberOfLifes.ToString();
    }
}
