﻿using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour
{
    EventManager eventManager;
    public string startScene;
    public Vector3 startPosition;
    float startRotation;

    void Start()
    {
        eventManager = GameObject.FindWithTag("MasterObject").GetComponent<EventManager>();
    }

    public void NewGame()
    {
        eventManager.InvoceSceneChange(startScene, startPosition, startRotation);
    }
}
