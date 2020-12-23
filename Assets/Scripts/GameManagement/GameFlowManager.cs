using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    public GameObject GeorgeFlurPicture;
    public GameObject GeorgeMamaPicture;
    public GameObject FredKitchenPicture;
    public GameObject FredMamaPicture;
    public GameObject WinPicture;

    GameObject FredKitchen;
    GameObject FredMama;
    GameObject GeorgeFlur;
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
                GeorgeFlur = GameObject.FindGameObjectWithTag("GeorgeFlur");
                MenuManager.ActivateMenu();
                goalManager.ProgressGoal("George");
                gameState.georgerFlowId++;
                cutscene.PlayWalkCutscene(GeorgeFlur, new Vector3(-4.07f, 0.13f, 3.1f), new Vector3(-5.05f, 0.13f, 1f));
                break;
            case 2:
                eventManager.InvokeInteract(2);
                Boxes = GameObject.FindGameObjectWithTag("Boxes").GetComponent<InteractObject>();
                Boxes.hasItem = true;
                Boxes.inspectText = new List<string>() { "Leckerlies!", "Ich hab viel zu kurze Arme" };                
                break;
            case 3:
                FredKitchenPicture.SetActive(true);
                MenuManager.ActivateMenu();
                FredKitchen = GameObject.FindGameObjectWithTag("FredKitchen");                
                goalManager.ProgressGoal("Fred");
                gameState.fredFlowId++;
                cutscene.PlayWalkCutscene(FredKitchen, new Vector3(-6, 0.5f, -5.5f), new Vector3(-5.5f, 0.5f, -0.5f));
                break;
            case 4:
                GeorgeFlur = GameObject.FindGameObjectWithTag("GeorgeFlur");
                goalManager.ProgressGoal("George");
                gameState.georgerFlowId++;
                cutscene.PlayWalkCutscene(GeorgeFlur, new Vector3(-9.71f, 3.42f, 1f), new Vector3(-9.18f, 3.42f, 4.31f));
                break;
            case 5:
                FredMama = GameObject.FindGameObjectWithTag("FredMama");
                FredMamaPicture.SetActive(true);
                MenuManager.ActivateMenu();
                goalManager.ProgressGoal("Fred");
                gameState.fredFlowId++;
                cutscene.PlayWalkCutscene(FredMama, new Vector3(-6.48f, 3.26f, -5.5f), new Vector3(-8.5f, 3.15f, -1.3f));
                break;
            case 6:
                eventManager.InvokeInteract(3);
                break;
            case 7:
                //cutscene
                var GeorgeMama = GameObject.FindGameObjectsWithTag("GeorgeFlur").First();
                goalManager.ProgressGoal("George");
                gameState.georgerFlowId++;
                MenuManager.ActivateMenu();
                GeorgeMamaPicture.SetActive(true);
                cutscene.PlayWalkCutscene(GeorgeMama, new Vector3(-12.28f, 3.15f, -5.41f), new Vector3(-8.5f, 3.15f, -1.3f));
                if (gameState.fredFlowId == 2)
                {
                    MenuManager.ActivateMenu();
                    WinPicture.SetActive(true);
                }
                break;
            case 8:
                FredKitchen = GameObject.FindGameObjectWithTag("FredKitchen");
                goalManager.ProgressGoal("Fred");
                gameState.fredFlowId++;
                cutscene.PlayWalkCutscene(FredKitchen, new Vector3(-13.81f, 3.3f, 11.3f), new Vector3(-12.35f, 1.99f, 6.83f));
                if (gameState.georgerFlowId == 2)
                {
                    MenuManager.ActivateMenu();
                    WinPicture.SetActive(true);
                }
                break;
            default:
                break;
        }
    }
}