using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void ChangeSceneTo(string name)
    {
        SceneManager.LoadScene(name);
    }
}
