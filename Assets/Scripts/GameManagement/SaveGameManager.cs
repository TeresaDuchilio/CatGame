using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveGameManager : MonoBehaviour
{
    public GameState state;
    EventManager eventManager;

    public void Start()
    {
        state = GameState.Instance;
        eventManager = GameObject.FindWithTag("MasterObject").GetComponent<EventManager>();
    }
    public void CreateSaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, state);
        file.Close();

        Debug.Log("Game Saved");
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            GameState save = (GameState)bf.Deserialize(file);
            file.Close();

            state.SetGameState(save);
            eventManager.InvoceSceneChange(save.Scene, save.AgentPosition, save.AgentRotation);
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }
}
