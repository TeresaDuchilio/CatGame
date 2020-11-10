using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public sealed class GameState
{
    public List<InteractObject> Objects { get; set; }
    public Inventory Inventory { get; set; }
    public string Scene { get; set; }
    public Vector3 AgentPosition { get; set; }
    public float AgentRotation { get; set; }

    private GameState()
    {
        Objects = new List<InteractObject>();
    }

    private static readonly Lazy<GameState> lazy = new Lazy<GameState>(() => new GameState());

    public static GameState Instance
    {
        get
        {
            return lazy.Value;
        }
    }

    public void UpdateObject(InteractObject interactObject)
    {
        foreach (InteractObject obj in Objects)
        {
            if (obj.ID == interactObject.ID)
            {
                obj.itemId = interactObject.itemId;
                obj.interactItemId = interactObject.interactItemId;
                obj.hasItem = interactObject.hasItem;
                obj.interactable = interactObject.interactable;
                break;
            }
        }
    }

    public void SetGameState(GameState state)
    {
        this.AgentPosition = state.AgentPosition;
        this.AgentRotation = state.AgentRotation;
        this.Inventory = state.Inventory;
        this.Objects = state.Objects;
        this.Scene = state.Scene;
    }
}