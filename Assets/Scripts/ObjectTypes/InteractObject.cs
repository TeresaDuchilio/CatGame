using UnityEngine;
using UnityEngine.EventSystems;

public class InteractObject : MonoBehaviour, IClickableObject, IDropHandler
{
    public string inspectText;
    public int itemId;

    public int interactItemId;

    EventManager eventManager;
    bool hasItem;
    bool interactable;

    void Start()
    {
        eventManager = GameObject.FindWithTag("MasterObject").GetComponent<EventManager>();
        hasItem = itemId != 0;
        interactable = true;
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

    public void OnDrop(PointerEventData eventData)
    {
        var item = eventData.pointerDrag.GetComponent<Item>();
        if(item.Id == interactItemId)
        {
            Debug.Log("Do something with this item");
            interactable = false;
            eventManager.InvokeRemoveFromInventory(item.gameObject);
        }
    }
}