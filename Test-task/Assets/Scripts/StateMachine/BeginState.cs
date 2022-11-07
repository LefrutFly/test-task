using System.Collections;

public class BeginState : State
{
    private GameStateMachine gameStateMachine;
    public BeginState(StateMachine stateMachine) : base(stateMachine) { }

    public override IEnumerator Start()
    {
        yield break;
    }
}
