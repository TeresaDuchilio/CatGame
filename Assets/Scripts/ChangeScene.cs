using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeSceneTo(string name)
    {
        SceneManager.LoadScene(name);
    }
}
