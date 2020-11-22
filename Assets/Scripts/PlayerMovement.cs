using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent agent;
    IClickableObject selectedObject;
    bool interact;

    bool warping;
    Vector3 warpPosition;
    float warpRotation;
    string currentScene;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        interact = false;
        warping = false;
    }

    private void Update()
    {
        if (!MenuManager.Active)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.transform.tag == "Floor" || hit.transform.tag == "Door")
                    {
                        Vector3 destination = hit.point;

                        if (hit.transform.tag == "Door")
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
                    else
                    {
                        var interaction = hit.transform.GetComponentInParent<IClickableObject>();
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
                    selectedObject = hit.transform.GetComponentInParent<IClickableObject>();

                    if (selectedObject != null)
                    {
                        NavMeshHit meshHit;
                        if (NavMesh.SamplePosition(hit.transform.position, out meshHit, 5.0f, NavMesh.AllAreas))
                        {
                            interact = true;
                            agent.SetDestination(meshHit.position);
                        }
                    }
                }
            }
        }

        if (interact && IsPathComplete())
        {
            selectedObject.RightClick();
            interact = false;
        }

        if (warping)
        {
            if (SceneManager.GetActiveScene().name == currentScene)
            {                
                warping = false;
                agent.enabled = false;
                transform.position = warpPosition;
                transform.rotation = Quaternion.AngleAxis(warpRotation, Vector3.up);
                agent.enabled = true;
            }
        }
    }

    public void WarpToPosition(Vector3 position, float rotation, string scene)
    {
        warping = true;
        warpPosition = position;
        warpRotation = rotation;
        currentScene = scene;
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
