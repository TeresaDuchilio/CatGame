using UnityEngine;
using UnityEngine.AI;


public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent agent;

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
                    var interaction = hit.transform.GetComponent<IClickableObject>();
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
                var interaction = hit.transform.GetComponent<IClickableObject>();
                interaction.RightClick();
            }
        }
    }

    public void WarpToPosition(Vector3 position, float rotation)
    {
        agent.Warp(position);
        transform.rotation = Quaternion.AngleAxis(rotation, Vector3.up);  
    }
}
