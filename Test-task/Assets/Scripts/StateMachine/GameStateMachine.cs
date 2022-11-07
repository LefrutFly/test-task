using Zenject;

public class GameStateMachine : StateMachine
{
    [Inject] private Player player;
    [Inject] private Screens screens;

    public Player Player => player;
    public Screens Screens => screens;


    private void Awake()
    {
        SetState(new BeginState(this));
    }
}