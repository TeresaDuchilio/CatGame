using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PickUpObject : MonoBehaviour, IClickableObject
{
    public int ID;
    public List<string> inspectText = new List<string>(0);
    public int itemId;

    EventManager eventManager;
    GameState gameState;

    void Start()
    {
        gameState = GameState.Instance;
        eventManager = GameObject.FindWithTag("MasterObject").GetComponent<EventManager>();

        var thisObject = gameState.PickUps.Where(x => x.ID == this.ID).FirstOrDefault();


        if (thisObject != null)
        {
            if (!thisObject.active)
            {
                this.gameObject.SetActive(false);
            }
        }
        else
        {
            gameState.AddPickUpState(this);
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
            gameState.DisablePickup(this);
            eventManager.InvokeInteract(itemId);
            gameObject.SetActive(false);
        }
    }
}
