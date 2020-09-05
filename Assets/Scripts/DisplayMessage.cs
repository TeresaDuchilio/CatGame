using UnityEngine;
using UnityEngine.UI;

public class DisplayMessage : MonoBehaviour
{
    Text textObject;

    void Start()
    {
        textObject = GetComponent<Text>();
    }

    public void SetText(string newText)
    {
        textObject.text = newText;
    }

    public void Test()
    {
        Debug.Log("yay");
    }
}
