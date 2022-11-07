using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    private State currentState;

    public void SetState(State state)
    {
        if (currentState != null)
            StartCoroutine(currentState.End());

        currentState = state;
        StartCoroutine(currentState.Start());
    }

}