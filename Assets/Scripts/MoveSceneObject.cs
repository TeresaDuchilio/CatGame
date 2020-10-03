using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MoveSceneObject : MonoBehaviour, IClickableObject
{
    public string sceneName;

    public void LeftClick()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void RightClick()
    {
        throw new System.NotImplementedException();
    }
}
