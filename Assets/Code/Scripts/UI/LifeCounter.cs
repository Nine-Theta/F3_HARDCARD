using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class LifeCounter : MonoBehaviour
{
    [SerializeField] int numberOfLifes = 3;

    [SerializeField] TMP_Text textBox;

    public void UpdateCounter()
    {
        numberOfLifes--;
        if(numberOfLifes <= 0)
        {
            SceneManager.LoadScene(3);
        }    
        textBox.text = numberOfLifes.ToString();
    }
}
