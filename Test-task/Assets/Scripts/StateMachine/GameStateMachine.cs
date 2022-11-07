using Zenject;

public class GameStateMachine : StateMachine
{
    [Inject] private Player player;
    [Inject] private Screens screens;
    [Inject] private Timer timer;
    [Inject] private MovableTerrain movableTerrain;

    private int countTry = 0;

    public Player Player => player;
    public Screens Screens => screens;
    public Timer Timer => timer;
    public MovableTerrain MovableTerrain => movableTerrain;
    public int CountTry 
    { 
        get => countTry;
        set
        {
            if (value < 0) return;
            else countTry = value;

            Saver.SaveCountTry(countTry);
        }
    }


    private void Awake()
    {
        CountTry = Saver.LoadCountTry();

        SetState(new BeginState(this));
    }
}
