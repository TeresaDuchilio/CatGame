﻿using UnityEngine;
using UnityEngine.UI;

public class InteractObject : MonoBehaviour, IClickableObject
{
    public Text text;
    public EventManager eventManager;

    public void LeftClick()
    {
        PutText("Inspect");
        Debug.Log("Inspect");
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
