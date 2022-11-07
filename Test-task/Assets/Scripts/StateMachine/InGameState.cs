using System.Collections;
using UnityEngine;

public class InGameState : State
{
    private GameStateMachine gameStateMachine;
    private Player player;
    private Screens screens;
    private Difficulty difficulty;
    private Timer timer;

    public InGameState(StateMachine stateMachine) : base(stateMachine) { }

    public override IEnumerator Start()
    {
        gameStateMachine = stateMachine as GameStateMachine;    
        player = gameStateMachine.Player;
        screens = gameStateMachine.Screens;
        difficulty = screens.StartScreen.Difficulty;
        timer = gameStateMachine.Timer;

        EnableInGameScreen();
        EnablePlayer();
        SetStartPositionPlayer();
        SetStartVelocityVerticalPlayer();
        ChoosePlayerDifficulty();
        RestartCurrentTimer();
        RestartLastTimer();
        AddTry();

        player.LoseGameEvent += SetLoseState;

        yield break;
    }

    public override IEnumerator End()
    {
        player.LoseGameEvent -= SetLoseState;

        ResetMaxTimer();

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

    private void SetStartPositionPlayer()
    {
        player.SetStartPosiotion();
    }

    private void SetStartVelocityVerticalPlayer()
    {
        player.Move.SetStartVelocityVertical();
    }

    private void ChoosePlayerDifficulty()
    {
        player.Move.ChooseDifficulty(difficulty);
    }

    private void RestartCurrentTimer()
    {
        timer.ResetCurrentTimer();
    }

    private void RestartLastTimer()
    {
        timer.RestartLastTimer();
    }

    private void ResetMaxTimer()
    {
        timer.ResetTimer();
    }

    private void AddTry()
    {
        gameStateMachine.CountTry++;
    }

    private void SetLoseState()
    {
        stateMachine.SetState(new LoseState(stateMachine));
    }
}
