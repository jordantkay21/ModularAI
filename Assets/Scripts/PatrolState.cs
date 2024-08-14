using System;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : State
{

    private PatrolManager patrolManager;
    private NavMeshAgent navMeshAgent;

    private float waitTime;
    private bool waiting;
    private float waitTimer;

    public PatrolState(GameObject owner, PatrolManager patrolMgr) : base(owner)
    {
        patrolManager = patrolMgr;
        navMeshAgent = owner.GetComponent<NavMeshAgent>();
    }

    public override void Enter()
    {
        Debug.Log("Entering Patrol State");
        PatrolZone patrolZone = patrolManager.GetAssignedPatrolZone(owner);

        if (patrolZone != null)
            MoveToNextPatrolPoint(patrolZone);
        else
            Debug.Log("No Patrol Zones Assigned");
    }


    public override void Update()
    {
        if (waiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTime)
            {
                waiting = false;

                PatrolZone patrolZone = patrolManager.GetAssignedPatrolZone(owner);
                if (patrolZone != null)
                    MoveToNextPatrolPoint(patrolZone);
            }
        }
        else if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
        {
            StartWaiting();
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting Patrol State");
    }

    private void MoveToNextPatrolPoint(PatrolZone patrolZone)
    {
        PatrolPoint nextPoint = patrolZone.GetNextPatrolPoint();

        if (nextPoint != null)
        {
            navMeshAgent.SetDestination(nextPoint.Position);
            waitTime = nextPoint.WaitTime; //Store the wait time for the current point
            //Debug.Log($"Moving to patrol point at: {nextPoint.Position}");
        }
        else
        {
            Debug.Log("No Patrol point available");
        }
    }

    private void StartWaiting()
    {
        waiting = true;
        waitTimer = 0f;
    }
}
