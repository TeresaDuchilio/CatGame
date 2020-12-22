using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {

    [SerializeField] private Canvas canvas;

    public bool newPositionFound;
    public Inventory Inventory;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    Vector2 startPosition;

    private void Awake() {
        newPositionFound = false;
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");
        newPositionFound = false;
        startPosition = rectTransform.anchoredPosition;
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        if (!newPositionFound)
        {
            rectTransform.anchoredPosition = startPosition;
            newPositionFound = false;
        }
        else
        {
            var startSlot = Inventory.GetSlotByPosition(startPosition);
            Inventory.RemoveFromSlot(startSlot);
        }
    }

    public void OnPointerDown(PointerEventData eventData) {        
        Debug.Log("OnPointerDown");
    }

}
