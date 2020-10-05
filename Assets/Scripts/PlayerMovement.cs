using System.Runtime.InteropServices.WindowsRuntime;
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
                if (hit.transform.tag == "Floor" || hit.transform.tag == "Door") {
                    Vector3 destination = hit.point;

                    if(hit.transform.tag == "Door")
                    {
                        NavMeshHit meshHit;
                        if (NavMesh.SamplePosition(destination, out meshHit, 5.0f, NavMesh.AllAreas))
                        {
                            destination = meshHit.position;
                        }
                    }
                    agent.SetDestination(destination);
                }
                else {
                    var interaction = hit.transform.GetComponent<IClickableObject>();
                    if (interaction != null)
                    {
                        interaction.LeftClick();
                    }
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
                if (interaction != null)
                {
                    interaction.RightClick();
                }
            }
        }
    }

    //Returns true once agent reaches position
    public bool MoveToPosition(Vector3 position)
    {
        agent.SetDestination(position);
        //position = agent.destination;

        while(agent.transform.position != position)
        {
            if(agent.destination != position)
            {
                return false;
            }
        }
        return true;
    }
    public void WarpToPosition(Vector3 position, float rotation)
    {
        agent.Warp(position);
        transform.rotation = Quaternion.AngleAxis(rotation, Vector3.up);  
    }
}
