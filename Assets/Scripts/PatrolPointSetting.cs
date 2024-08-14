using UnityEngine;

[System.Serializable]
public class PatrolPointSetting
{
    public GameObject patrolPoint;
    public float waitTime;

    public PatrolPointSetting(GameObject point, float time)
    {
        patrolPoint = point;
        waitTime = time;
    }
}
