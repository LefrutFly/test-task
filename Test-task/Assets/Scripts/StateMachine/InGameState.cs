using System.Collections;
using UnityEngine;

public class InGameState : State
{
    private GameStateMachine gameStateMachine;
    private Player player;
    private Screens screens;
    private Difficulty difficulty;
    private Timer timer;
    private MovableTerrain movableTerrain; 

    public InGameState(StateMachine stateMachine) : base(stateMachine) { }

    public override IEnumerator Start()
    {
        gameStateMachine = stateMachine as GameStateMachine;    
        player = gameStateMachine.Player;
        screens = gameStateMachine.Screens;
        difficulty = screens.StartScreen.Difficulty;
        timer = gameStateMachine.Timer;
        movableTerrain = gameStateMachine.MovableTerrain;

        EnableInGameScreen();
        EnablePlayer();
        SetStartPositionPlayer();
        SetStartVelocityVerticalPlayer();
        ChooseDifficulty();
        RestartCurrentTimer();
        RestartLastTimer();
        AddTry();
        ResetMove();

        player.LoseGameEvent += SetLoseState;

        yield break;
    }

    public override IEnumerator End()
    {
        player.LoseGameEvent -= SetLoseState;

        ResetMaxTimer();
        StopMove();

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

    private void ChooseDifficulty()
    {
        movableTerrain.ChooseDifficulty(difficulty);
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

    private void ResetMove()
    {
        movableTerrain.ResetPosiotion();
        movableTerrain.StartMove();
    }

    private void StopMove()
    {
        movableTerrain.StopMove();
    }

    private void SetLoseState()
    {
        stateMachine.SetState(new LoseState(stateMachine));
    }
}
