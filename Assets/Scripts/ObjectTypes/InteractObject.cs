﻿using System;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class InteractObject : MonoBehaviour, IClickableObject, IDropHandler
{
    public int ID;
    public string inspectText;
    public string inspectTextAfterInteract;
    public int itemId;
    public bool hasItem;
    public bool interactable;
    public int interactItemId;
    public int gameFlowId;

    EventManager eventManager;
    GameState gameState;

    void Start()
    {
        eventManager = GameObject.FindWithTag("MasterObject").GetComponent<EventManager>();
        gameState = GameState.Instance;
        //hasItem = itemId != 0;
        interactable = true;

        var thisObject = gameState.Objects.Where(x => x.ID == this.ID).FirstOrDefault();

        if (thisObject != null)
        {
            itemId = thisObject.itemId;
            interactItemId = thisObject.interactItemId;
            hasItem = thisObject.hasItem;
            interactable = thisObject.interactable;
        }
        else
        {
            gameState.AddInteractState(this);
        }
    }

    public void LeftClick()
    {
        if (!MenuManager.Active)
        {
            eventManager.InvokeLookAt(inspectText);
        }
    }

    public void RightClick()
    {
        if (!MenuManager.Active)
        {

            Debug.Log("Interact");
            if (hasItem)
            {
                eventManager.InvokeInteract(itemId);
                hasItem = false;
            }
            gameState.UpdateObject(this);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        var item = eventData.pointerDrag.GetComponent<Item>();
        if(item.Id == interactItemId)
        {
            Debug.Log("Do something with this item");
            interactable = false;
            inspectText = inspectTextAfterInteract;
            eventManager.InvokeRemoveFromInventory(item.gameObject);
            eventManager.InvokeGameFlowProgression(gameFlowId);
        }
        gameState.UpdateObject(this);
    }
}