using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    public GameObject GeorgeFlurPicture;
    public GameObject FredKitchenPicture;
    public GameObject FredMamaPicture;


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
                gameState.georgerFlowId++;
                break;
            case 2:
                eventManager.InvokeInteract(2);
                Boxes = GameObject.FindGameObjectWithTag("Boxes").GetComponent<InteractObject>();
                Boxes.hasItem = true;
                Boxes.inspectText = new List<string>() { "Leckerlies!", "Ich hab viel zu kurze Arme" };                
                break;
            case 3:
                FredKitchenPicture.SetActive(true);
                MenuManager.Active = true;
                FredKitchen = GameObject.FindGameObjectWithTag("FredKitchen");                
                goalManager.ProgressGoal("Fred");
                gameState.fredFlowId++;
                cutscene.PlayWalkCutscene(FredKitchen, new Vector3(-6, 0.5f, -5.5f), new Vector3(-5.5f, 0.5f, -0.5f));
                break;
            case 4:
                //cutscene
                GameObject.FindGameObjectsWithTag("GeorgeFlur").First().SetActive(false);
                goalManager.ProgressGoal("George");
                gameState.georgerFlowId++;
                break;
            case 5:
                FredMamaPicture.SetActive(true);
                MenuManager.Active = true;
                goalManager.ProgressGoal("Fred");
                gameState.fredFlowId++;
                break;
            case 6:
                eventManager.InvokeInteract(3);
                break;
            case 7:
                //cutscene
                GameObject.FindGameObjectsWithTag("GeorgeFlur").First().SetActive(false);
                goalManager.ProgressGoal("George");
                gameState.georgerFlowId++;
                break;
            case 8:
                //cutscene
                GameObject.FindGameObjectsWithTag("FredKitchen").First().SetActive(false);
                goalManager.ProgressGoal("Fred");
                gameState.fredFlowId++;
                break;
            default:
                break;
        }
    }
}