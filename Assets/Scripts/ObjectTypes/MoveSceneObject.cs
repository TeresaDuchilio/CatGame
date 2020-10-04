using UnityEngine;

public class MoveSceneObject : MonoBehaviour, IClickableObject
{
    public EventManager eventManager;
    public string sceneName;
    public Vector3 characterPosition;

    public void LeftClick()
    {
        eventManager.InvoceSceneChange(sceneName, characterPosition);
    }

    public void RightClick()
    {
        throw new System.NotImplementedException();
    }
}
