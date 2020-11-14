using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    public GameObject GeorgeFlurPicture;
    public InteractObject TreatShelf;

    EventManager eventManager;

    private void Start()
    {
        eventManager = GameObject.FindWithTag("MasterObject").GetComponent<EventManager>();
    }

    public void HandleGameEvent(int id)
    {
        switch (id)
        {
            case 0:
                GeorgeFlurPicture.SetActive(true);
                break;
            case 1:
                //give item, change text
                eventManager.InvokeInteract(3);
                TreatShelf.inspectText = "no treats here";
                break;
            default:
                break;
        }
    }
}