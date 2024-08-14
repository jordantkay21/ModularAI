using UnityEngine;

public class PatrolPoint
{
    public Vector3 Position { get; private set; }
    public float WaitTime { get; private set; }

    public PatrolPoint(Vector3 position, float waitTime)
    {
        Position = position;
        WaitTime = waitTime;
    }
}
