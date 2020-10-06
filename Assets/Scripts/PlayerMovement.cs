using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.AI;


public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent agent;
    IClickableObject selectedObject;
    bool interact;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        interact = false;
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
                    interact = false;
                    agent.SetDestination(destination);
                }
                else {
                    var interaction = hit.transform.GetComponent<IClickableObject>();
                    if (interaction != null)
                    {
                        interact = false;
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
                selectedObject = hit.transform.GetComponent<IClickableObject>();

                NavMeshHit meshHit;
                if (NavMesh.SamplePosition(hit.transform.position, out meshHit, 5.0f, NavMesh.AllAreas))
                {
                    interact = true;
                    agent.SetDestination(meshHit.position);
                }
            }
        }

        if (interact && IsPathComplete())
        {
            selectedObject.RightClick();
            interact = false;
        }
    }

    public void WarpToPosition(Vector3 position, float rotation)
    {
        agent.Warp(position);
        transform.rotation = Quaternion.AngleAxis(rotation, Vector3.up);  
    }

    bool IsPathComplete()
    {
        if (Vector3.Distance(transform.position, agent.destination) <= 1f)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
