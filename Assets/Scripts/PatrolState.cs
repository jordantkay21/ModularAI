using System;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : State
{
    private PatrolManager patrolManager;
    private NavMeshAgent navMeshAgent;

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
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
        {
            PatrolZone patrolZone = patrolManager.GetAssignedPatrolZone(owner);

            if (patrolZone != null)
                MoveToNextPatrolPoint(patrolZone);
            //else
                //Debug.Log("No Patrol Zones Assigned");
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
            Debug.Log($"Moving to patrol point at: {nextPoint.Position}");
        }
        else
        {
            Debug.Log("No Patrol point available");
        }
    }
}
