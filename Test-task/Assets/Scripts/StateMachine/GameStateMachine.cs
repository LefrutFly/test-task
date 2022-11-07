public class GameStateMachine : StateMachine
{
    private void Awake()
    {
        SetState(new BeginState(this));
    }
}