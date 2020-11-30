using UnityEngine;

public class ActiveInGameStateFred : MonoBehaviour
{
    public int from;
    public int until;

    GameState gameState;
    void Awake()
    {
        gameState = GameState.Instance;

        if(gameState.fredFlowId >= until || gameState.fredFlowId < from)
        {
            this.gameObject.SetActive(false);
        }
    }

}
