using System.Collections.Generic;

public class PatrolZone
{
    private List<PatrolPoint> patrolPoints;
    private int currentPointIndex = 0;

    public PatrolZone(List<PatrolPoint> points)
    {
        patrolPoints = points;
    }

    public PatrolPoint GetNextPatrolPoint()
    {
        if (patrolPoints.Count == 0)
            return null;

        PatrolPoint nextPoint = patrolPoints[currentPointIndex];
        currentPointIndex = (currentPointIndex + 1) % patrolPoints.Count;
        return nextPoint;
    }

    public void AddPatrolPoint(PatrolPoint point)
    {
        patrolPoints.Add(point);
    }

    public void RemovePatrolPoint(PatrolPoint point)
    {
        patrolPoints.Remove(point);
    }

    public void Reset()
    {
        currentPointIndex = 0;
    }
}
