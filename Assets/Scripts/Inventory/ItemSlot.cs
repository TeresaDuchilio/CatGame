using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public bool hasItem;
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
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = slotPosition;
            eventData.pointerDrag.GetComponent<DragDrop>().newPositionFound = true;
        }
    }

    public void AddToSlot(GameObject item)
    {
        item.SetActive(true);
        var itemTransform = item.GetComponent<RectTransform>();
        if (!hasItem && itemTransform != null)
        {
            hasItem = true;
            itemTransform.anchoredPosition = slotPosition;
        }
    }

    public void RemoveItem()
    {
        hasItem = false;
    }
}