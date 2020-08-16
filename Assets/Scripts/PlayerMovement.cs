using UnityEngine;
using UnityEngine.AI;


public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "Floor" ) {
                    agent.SetDestination(hit.point);
                }
                else {
                    var interaction = hit.transform.GetComponent<ClickableObject>();
                    interaction.LeftClick();
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                var interaction = hit.transform.GetComponent<ClickableObject>();
                interaction.RightClick();
            }
        }
    }
}
