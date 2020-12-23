using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject menu;
    public string startScene;

    bool firstStart;

    public StartGame()
    {
        firstStart = true;
    }

    public void NewGame()
    {
        if (firstStart)
        {
            SceneManager.LoadScene(startScene);
            firstStart = false;
        }
        menu.SetActive(false);
        MenuManager.Active = false;
    }
}
