using UnityEngine;

public class EventManager : MonoBehaviour
{
    public LookAtEvent lookAtEvent;
    public InteractEvent interactEvent;


    public void InvokeLookAt(string text)
    {
        lookAtEvent.Invoke(text);
    }

    public void InvokeInteract(string text)
    {
        lookAtEvent.Invoke(text);
    }
}
