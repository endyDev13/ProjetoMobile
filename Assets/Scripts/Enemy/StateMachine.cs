using UnityEngine;

public class StateMachine
{
    private IState currentState;
    private MonoBehaviour owner;

    public StateMachine(MonoBehaviour owner)
    {
        this.owner = owner;
    }

    public void ChangeState(IState newState)
    {
        if (currentState != null)
            currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    public void Update()
    {
        if (currentState != null)
            currentState.Update();
    }
}
