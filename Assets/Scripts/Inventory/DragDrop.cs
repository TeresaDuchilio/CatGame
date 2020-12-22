using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {

    [SerializeField] private Canvas canvas;

    public bool newPositionFound;
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
        //Debug.Log("OnDrag");
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
    }

    public void OnPointerDown(PointerEventData eventData) {        
        Debug.Log("OnPointerDown");
    }

}
