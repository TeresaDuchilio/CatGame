﻿using UnityEngine;

public class EventManager : MonoBehaviour
{
    public LookAtEvent lookAtEvent;
    public InteractEvent interactEvent;
    public SceneChangeEvent sceneChangeEvent;
    public MoveObjectEvent moveObjectEvent;

    public void InvokeLookAt(string text)
    {
        lookAtEvent.Invoke(text);
    }

    public void InvokeInteract(int itemId)
    {
        interactEvent.Invoke(itemId);
    }

    public void InvoceSceneChange(string sceneName, Vector3 characterPosition, float rotation)
    {
        sceneChangeEvent.Invoke(sceneName);
        moveObjectEvent.Invoke(characterPosition, rotation);
    }
}
