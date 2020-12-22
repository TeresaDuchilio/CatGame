using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CursorManager : MonoBehaviour {

    public static CursorManager Instance { get; private set; }

    public event EventHandler<OnCursorChangedEventArgs> OnCursorChanged;
    public class OnCursorChangedEventArgs : EventArgs {
        public CursorType cursorType;
    }

    [SerializeField] private List<CursorTypeTexture> cursorTextureList;

    private CursorTypeTexture cursorTexture;

    public enum CursorType {
        Arrow,
        LookAndInteract,
        Look,
        MoveScene,
        NPC
    }

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        ResetCursor();
    }


    public void SetActiveCursorType(CursorType cursorType) {
        cursorTexture = cursorTextureList.Where(x => x.cursorType == cursorType).FirstOrDefault();
        if (cursorTexture != null)
        {
            Cursor.SetCursor(cursorTexture.texture, cursorTexture.offset, CursorMode.ForceSoftware);
        }
        else
        {
            Debug.LogError("Cursor type not found");
        }
    }

    public void ResetCursor()
    {
        SetActiveCursorType(CursorType.Arrow);
    }

    [System.Serializable]
    public class CursorTypeTexture
    {
        public CursorType cursorType;
        public Texture2D texture;
        public Vector2 offset;
    }

}
