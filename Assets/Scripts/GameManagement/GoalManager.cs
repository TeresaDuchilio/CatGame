using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public GameObject[] fredGoal;
    public GameObject[] georgeGoal;

    public void ProgressGoal(string goal)
    {
        if(goal == "Fred")
        {
            AddHeart(fredGoal);
        }
        else
        {
            AddHeart(georgeGoal);
        }
    }

    void AddHeart(GameObject[] goal)
    {
        foreach (GameObject heart in goal)
        {
            if (!heart.activeSelf)
            {
                heart.SetActive(true);
                break;
            }
        }
    }
}
