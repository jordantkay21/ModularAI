using UnityEngine;

public class IdleState : State
{
    //Constructor to initialize the state witht he owner GameObject
    public IdleState(GameObject owner) : base(owner) { }

    //Method called when entering the Idle state
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
        //EXAMPLE: Check if a condition is met to exit the idle state
        /*
         * if (Condition to change state, e.g., player is detected)
         * {
         *    //Trigger a state change here
         *    //This will be handled by the State Manager
        */
    }

    //Method called when exiting the Idle State
    public override void Exit()
    {
        Debug.Log("Exiting Idle State");
        //EXAMPLE: Reset any idle-specific variables or conditions
    }

}
