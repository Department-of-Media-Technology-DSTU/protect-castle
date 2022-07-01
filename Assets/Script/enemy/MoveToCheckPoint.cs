using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToCheckPoint : MonoBehaviour
{
    private NavMeshAgent myAgent;
    private Animator myAnimator;
    public Transform[] Waypoints;
    int curWaypointIndex = 0;
    

    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        myAgent.enabled = true;
        myAnimator = GetComponent<Animator>();
        
    }


    // Update is called once per frame
    void Update()
    {
        if( curWaypointIndex <=Waypoints.Length - 1) 
        {
            myAnimator.Play("Walking");
            myAgent.SetDestination(Waypoints[curWaypointIndex].position);

            if (Vector3.Distance(transform.position, Waypoints[curWaypointIndex].position) < 1)
            {
                curWaypointIndex++;
            }
        }
        else
        {
            myAnimator.enabled = false;
            Destroy(gameObject);
            GameManagerBehavior gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
            gameManager.Health -= 1;
        }
        
}

    // The code calculates the length of the path not yet traveled by the enemy
    // I've replaced Waypoints[curWaypointIndex + 1] on Waypoints[curWaypointIndex]
    public float DistanceToGoal()
    {
        float distance = 0;
        distance += Vector2.Distance(gameObject.transform.position, Waypoints[curWaypointIndex].transform.position);
        for (int i = curWaypointIndex; i < Waypoints.Length - 1; i++)
        {
            Vector3 startPosition = Waypoints[i].transform.position;
            Vector3 endPosition = Waypoints[i + 1].transform.position;
            distance += Vector2.Distance(startPosition, endPosition);
        }
        return distance;
    }
}
