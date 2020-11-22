using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMessage : MonoBehaviour
{
    public GameObject textBox;

    Text textObject;
    Image textBoxImage;

    void Start()
    {
        textObject = GetComponent<Text>();
        textBoxImage = textBox.GetComponent<Image>();
        textBoxImage.enabled = false;
    }

    public void SetText(List<string> newText)
    {
        if (newText.Count > 0)
        {
            StartCoroutine("HandleTextDisplay", newText);
        }
    }

    public IEnumerator HandleTextDisplay(List<string> text)
    {
        MenuManager.Active = true;
        yield return new WaitForFixedUpdate();

        textBoxImage.enabled = true;
        textObject.text = text[0];

        int i = 1;

        while (i <= text.Count)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (i == text.Count)
                {
                    textObject.text = string.Empty;
                    textBoxImage.enabled = false;
                    MenuManager.Active = false;
                    yield break;
                }
                else
                {
                    textObject.text = text[i];
                    i++;
                }
            }
            yield return null;
        }
    }

    public void Test()
    {
        Debug.Log("yay");
    }
}
