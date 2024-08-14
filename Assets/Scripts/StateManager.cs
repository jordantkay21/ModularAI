using UnityEngine;

public class StateManager : MonoBehaviour
{
    private State currentState;

    private void Start()
    {
        PatrolManager patrolManager = FindObjectOfType<PatrolManager>();
        PatrolState patrolState = new PatrolState(gameObject, patrolManager);
        Initialized(patrolState); //Start with Patrolstate
    }
    
    private void Update()
    {
        if (currentState != null)
        {
            currentState.Update(); //Update the current state
        }
    }

    // Initialize the StateManager with the initial state
    public void Initialized(State startingState)
    {
        currentState = startingState;
        currentState.Enter(); //Enter the initial state
    }


    //Change  the current state to a new state
    public void ChangeState(State newState)
    {
        if (currentState != null)
            currentState.Exit();

        currentState = newState;
        currentState.Enter(); //Enter the new state

    }

}
