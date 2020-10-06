using UnityEngine;

public class InteractObject : MonoBehaviour, IClickableObject
{
    public string inspectText;
    public int itemId;

    EventManager eventManager;
    bool hasItem;

    void Start()
    {
        eventManager = GameObject.FindWithTag("MasterObject").GetComponent<EventManager>();
        hasItem = itemId != 0;
    }

    public void LeftClick()
    {
        eventManager.InvokeLookAt(inspectText);
    }

    public void RightClick()
    {
        Debug.Log("Interact");
        if (hasItem)
        {
            eventManager.InvokeInteract(itemId);
            hasItem = false;
        }
    }
}