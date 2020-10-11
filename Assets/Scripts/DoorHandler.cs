using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorHandler : MonoBehaviour
{
    public PlayerMovement playerMovement;

    public void ChangeSceneTo(string name)
    {
        SceneManager.LoadScene(name);
    }
}
