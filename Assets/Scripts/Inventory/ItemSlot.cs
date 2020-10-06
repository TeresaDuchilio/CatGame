using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    bool hasItem;

    public ItemSlot()
    {
        hasItem = false;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null && !hasItem)
        {
            hasItem = true;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<DragDrop>().newPositionFound = true;
        }
    }

    public void RemoveItem()
    {
        hasItem = false;
    }
}