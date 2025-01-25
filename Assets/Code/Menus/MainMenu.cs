using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ChangeScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }    

    public void Quit()
    {
        Application.Quit();
    }
}
