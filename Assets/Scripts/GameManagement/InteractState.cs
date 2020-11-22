using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class InteractState 
{
    public int ID;
    public List<string> inspectText;
    public int itemId;
    public bool hasItem;
    public bool interactable;
    public int interactItemId;
    public int gameFlowId;
}