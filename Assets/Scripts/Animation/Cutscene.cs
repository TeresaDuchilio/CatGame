using UnityEngine;
using UnityEngine.AI;

public class Cutscene
{
    public void PlayWalkCutscene(GameObject target, Vector3 startPosition, Vector3 endPosition)
    {
        var agent = target.GetComponent<NavMeshAgent>();
        var animator = target.GetComponent<Animator>();

        if (agent != null && animator != null)
        {
            target.transform.position = startPosition;
            animator.enabled = true;
            agent.enabled = true;

            agent.SetDestination(endPosition);
        }
        
    }
}
