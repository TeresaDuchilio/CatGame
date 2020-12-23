using UnityEngine;
using UnityEngine.AI;

public class AnimationController : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.isActiveAndEnabled && agent.remainingDistance <= 1f) 
        {
            animator.SetInteger("WalkState", 0);
        }
        else
        {
            animator.SetInteger("WalkState", 1);
        }
    }
}
