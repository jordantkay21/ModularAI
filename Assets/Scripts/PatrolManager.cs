using System.Collections.Generic;
using UnityEngine;

public class PatrolManager : MonoBehaviour
{
    private Dictionary<GameObject, PatrolZone> agentPatrolAssignments;

    private void Awake()
    {
        agentPatrolAssignments = new Dictionary<GameObject, PatrolZone>();
    }

    public void AssignPatrolZone(GameObject agent, PatrolZone zone)
    {
        if (agentPatrolAssignments.ContainsKey(agent))
            agentPatrolAssignments[agent] = zone;
        else
            agentPatrolAssignments.Add(agent, zone);
        Debug.Log($"Assigned patrol zone to agent {agent.name}");
    }

    public PatrolZone GetAssignedPatrolZone(GameObject agent)
    {
        if (agentPatrolAssignments.ContainsKey(agent))
            return agentPatrolAssignments[agent];

        Debug.Log($"No patrol zone assigned to agent: {agent.name}");
        return null;
    }
}
