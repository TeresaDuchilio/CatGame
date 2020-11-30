using UnityEngine;

public class ActiveInGameStateGeorge : MonoBehaviour
{
    public int from;
    public int until;

    GameState gameState;
    void Awake()
    {
        gameState = GameState.Instance;

        if(gameState.georgerFlowId >= until || gameState.georgerFlowId < from)
        {
            this.gameObject.SetActive(false);
        }
    }

}
