using UnityEngine;

public class DisableOnClick : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            this.gameObject.SetActive(false);
            MenuManager.Active = false;
        }
    }
}