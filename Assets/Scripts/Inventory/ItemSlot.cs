using System;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class ItemSlot : MonoBehaviour, IDropHandler
{
    public bool hasItem;
    public GameObject attachedItem;
    Vector2 slotPosition;

    public void Awake()
    {
        hasItem = false;
        slotPosition = GetComponent<RectTransform>().anchoredPosition;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null && !hasItem)
        {
            hasItem = true;
            attachedItem = eventData.pointerDrag;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = slotPosition;
            eventData.pointerDrag.GetComponent<DragDropItem>().newPositionFound = true;
        }
    }

    public void AddToSlot(GameObject item)
    {
        item.SetActive(true);
        var itemTransform = item.GetComponent<RectTransform>();
        if (!hasItem && itemTransform != null)
        {
            hasItem = true;
            attachedItem = item;
            itemTransform.anchoredPosition = slotPosition;
        }
    }

    public void RemoveItem()
    {
        hasItem = false;
        attachedItem = null;
    }
}