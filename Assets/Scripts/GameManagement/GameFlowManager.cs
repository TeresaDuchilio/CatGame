using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    public GameObject GeorgeFlurPicture;

    GameObject FredKitchen;
    InteractObject Boxes;
    EventManager eventManager;
    GoalManager goalManager;
    GameState gameState;
    Cutscene cutscene;

    private void Start()
    {
        MenuManager.Active = false;
        GameObject MasterObject = GameObject.FindWithTag("MasterObject");
        eventManager = MasterObject.GetComponent<EventManager>();
        goalManager = MasterObject.GetComponent<GoalManager>();
        gameState = GameState.Instance;
        cutscene = new Cutscene();
    }

    public void HandleGameEvent(int id)
    {
        switch (id)
        {
            case 0:
                GeorgeFlurPicture.SetActive(true);
                GameObject.FindGameObjectsWithTag("GeorgeFlur").First().SetActive(false);
                MenuManager.Active = true;
                goalManager.ProgressGoal("George");
                gameState.gameFlowId = 0;
                break;
            case 1:
                gameState.gameFlowId = 1;
                break;
            case 2:
                eventManager.InvokeInteract(2);
                gameState.gameFlowId = 2;
                break;
            case 3:
                FredKitchen = GameObject.FindGameObjectWithTag("FredKitchen");
                Boxes = GameObject.FindGameObjectWithTag("Boxes").GetComponent<InteractObject>();
                Boxes.hasItem = true;
                Boxes.inspectText = new List<string>() { "Leckerlies!", "Ich hab viel zu kurze Arme" };
                cutscene.PlayWalkCutscene(FredKitchen, new Vector3(-6, 0.5f, -5.5f), new Vector3(-5.5f, 0.5f, -0.5f));
                goalManager.ProgressGoal("Fred");
                gameState.gameFlowId = 3;
                break;
            case 4:

                break;
            default:
                break;
        }
    }
}