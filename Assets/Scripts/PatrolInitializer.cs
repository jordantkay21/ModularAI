using System.Collections.Generic;
using UnityEngine;

public class PatrolInitializer : MonoBehaviour
{
    public GameObject aiAgent; //Reference to your AI Agent GameObject
    public List<PatrolPointSetting> patrolPointsSettings; //Drag PatrolPoint1, PatrolPoint2, etc. into this list in the Inspector

    [System.Obsolete]
    private void Start()
    {
        //Convert GameObjects to PatrolPoints
        List<PatrolPoint> patrolPoints = new List<PatrolPoint>();
        foreach (PatrolPointSetting setting in patrolPointsSettings)
        {
            patrolPoints.Add(new PatrolPoint(setting.patrolPoint.transform.position,setting.waitTime));
        }

        //Create the PatrolZone
        PatrolZone patrolZone = new PatrolZone(patrolPoints);
        Debug.Log($"PatrolZone created with {patrolPoints.Count} points");

        //Find the PatrolManager and assign the patrol zone to the AI agent
        PatrolManager patrolManager = FindObjectOfType<PatrolManager>();
        patrolManager.AssignPatrolZone(aiAgent, patrolZone);

        // Debug to confirm assignment
        Debug.Log($"PatrolZone assigned to AI agent: {aiAgent.name}");
    }
}
