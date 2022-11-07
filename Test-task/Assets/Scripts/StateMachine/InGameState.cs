using System.Collections;
using UnityEngine;

public class InGameState : State
{
    private GameStateMachine gameStateMachine;
    private Player player;
    private Screens screens;
    private Difficulty difficulty;

    public InGameState(StateMachine stateMachine) : base(stateMachine) { }

    public override IEnumerator Start()
    {
        Debug.Log("InGame");
        gameStateMachine = stateMachine as GameStateMachine;    
        player = gameStateMachine.Player;
        screens = gameStateMachine.Screens;
        difficulty = screens.StartScreen.Difficulty;

        EnableInGameScreen();
        EnablePlayer();
        ChoosePlayerDifficulty();

        player.LoseGameEvent += SetLoseState;

        yield break;
    }

    public override IEnumerator End()
    {
        player.LoseGameEvent -= SetLoseState;

        yield break;
    }

    private void EnableInGameScreen()
    {
        screens.EnableInGameScreen();
    }

    private void EnablePlayer()
    {
        player.gameObject.SetActive(true);
    }

    private void ChoosePlayerDifficulty()
    {
        player.Move.ChooseDifficulty(difficulty);
    }

    private void SetLoseState()
    {
        stateMachine.SetState(new LoseState(stateMachine));
    }
}
