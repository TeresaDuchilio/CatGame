using UnityEngine;

public class MoveSceneObject : MonoBehaviour, IClickableObject
{
    EventManager eventManager;
    public string sceneName;
    public Vector3 characterPosition;
    public float rotation;
    GameState gameState;

    void Start()
    {
        eventManager = GameObject.FindWithTag("MasterObject").GetComponent<EventManager>();
        gameState = GameState.Instance;
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
        if (other.gameObject.tag == "Player")
        {
            gameState.AgentPosition = characterPosition;
            gameState.AgentRotation = rotation;
            gameState.Scene = sceneName;
            eventManager.InvoceSceneChange(sceneName, characterPosition, rotation);
        }
        else if(other.isTrigger)
        {
            Destroy(other.gameObject);
        }
    }
}
