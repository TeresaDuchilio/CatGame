using UnityEngine;

public class ActiveInGameState : MonoBehaviour
{
    public int from;
    public int until;

    GameState gameState;

    void Awake()
    {
        gameState = GameState.Instance;

        if(gameState.gameFlowId >= until || gameState.gameFlowId < from)
        {
            this.gameObject.SetActive(false);
        }
    }

}
