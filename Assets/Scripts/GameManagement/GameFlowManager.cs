﻿using System.Linq;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    public GameObject GeorgeFlurPicture;

    EventManager eventManager;
    GameState gameState;


    private void Start()
    {
        eventManager = GameObject.FindWithTag("MasterObject").GetComponent<EventManager>();
        gameState = GameState.Instance;
    }

    public void HandleGameEvent(int id)
    {
        switch (id)
        {
            case 0:
                GeorgeFlurPicture.SetActive(true);
                GameObject.FindGameObjectsWithTag("GeorgeFlur").First().SetActive(false);
                gameState.gameFlowId = 0;
                break;
            case 1:
                //give item, change text
                eventManager.InvokeInteract(3);
                break;
            default:
                break;
        }
    }
}