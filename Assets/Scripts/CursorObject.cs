using UnityEngine;

public class CursorObject : MonoBehaviour {

    [SerializeField] private CursorManager.CursorType cursorType;

    private void OnMouseEnter() {
        if (!MenuManager.Active)
        {
            CursorManager.Instance.SetActiveCursorType(cursorType);
        }
    }

    private void OnMouseExit() {
        CursorManager.Instance.SetActiveCursorType(CursorManager.CursorType.Arrow);
    }

}
