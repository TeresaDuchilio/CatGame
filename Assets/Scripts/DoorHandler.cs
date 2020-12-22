﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorHandler : MonoBehaviour
{
    public PlayerMovement playerMovement;
    EventManager eventManager;


    void Start()
    {
        eventManager = GameObject.FindWithTag("MasterObject").GetComponent<EventManager>();
    }

    public void ChangeSceneTo(string name)
    {
        SceneManager.LoadScene(name);
    }
}