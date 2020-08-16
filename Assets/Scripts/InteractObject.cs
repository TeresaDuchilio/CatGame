using UnityEngine;

public class InteractObject : MonoBehaviour, ClickableObject
{
    public void LeftClick()
    {
        Debug.Log("Inspect");
    }

    public void RightClick()
    {
        Debug.Log("Interact");
    }
}
