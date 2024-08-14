using UnityEngine;

public abstract class State
{
    protected GameObject owner;

    // Constructor to assign the owner of the AI state (the AI agent)
    public State(GameObject owner)
    {
        this.owner = owner;
    }

    //Method called when the state is entered
    public abstract void Enter();

    //Method called every frame while the state is active
    public abstract void Update();

    //Method called when the state is exited
    public abstract void Exit();

}
