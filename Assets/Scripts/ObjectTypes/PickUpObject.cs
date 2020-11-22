using UnityEngine;

public class PickUpObject : MonoBehaviour, IClickableObject
{
    public int ID;
    public string inspectText;
    public int itemId;
    public int gameFlowId;

    EventManager eventManager;

    void Start()
    {
        eventManager = GameObject.FindWithTag("MasterObject").GetComponent<EventManager>();
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
            eventManager.InvokeInteract(itemId);
            eventManager.InvokeGameFlowProgression(gameFlowId);
            gameObject.SetActive(false);
        }
    }
}
