using UnityEngine;
using UnityEngine.UI;

public class InteractObject : MonoBehaviour, IClickableObject
{
    public Text text;
    EventManager eventManager;

    void Start()
    {
        eventManager = GameObject.FindWithTag("MasterObject").GetComponent<EventManager>();
    }

    public void LeftClick()
    {
        PutText("Inspect");
    }

    public void RightClick()
    {
        Debug.Log("Interact");
    }

    void PutText(string text)
    {
        eventManager.InvokeLookAt(text);
    }
}
