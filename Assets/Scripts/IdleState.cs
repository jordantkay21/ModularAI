using UnityEngine;

public class IdleState : State
{
    public IdleState(GameObject owner) : base(owner) { }

    public override void Enter()
    {
        Debug.Log("entering Idle State");
        //EXAMPLE: Set animation to idle
        /*
         * owner.GetComponent<Animator>.SetTrigger("Idle");
        */
    }
    public override void Update()
    {
        //EXAMPLE: Check if the AI should transition to another state
        /*
         * if (some condition)
         * { Triggera state change }
        */
    }

    public override void Exit()
    {
        Debug.Log("Exiting Idle State");
        //EXAMPLE: Reset any idle-specific variables or conditions
    }

}
