using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSceneObject : MonoBehaviour, IClickableObject
{
    EventManager eventManager;
    public string sceneName;
    public Vector3 characterPosition;
    public float rotation;

    void Start()
    {
        eventManager = GameObject.FindWithTag("MasterObject").GetComponent<EventManager>();
    }

    public void LeftClick()
    {
        //nothing
    }

    public void RightClick()
    {
        //say something?
    }

    private void OnTriggerEnter(Collider other)
    {
        eventManager.InvoceSceneChange(sceneName, characterPosition, rotation);
    }
}
