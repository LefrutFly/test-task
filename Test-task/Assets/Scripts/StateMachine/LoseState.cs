using System.Collections;
using UnityEngine;

public class LoseState : State
{
    private GameStateMachine gameStateMachine;
    private Player player;
    private Screens screens;
    private Timer timer;

    public LoseState(StateMachine stateMachine) : base(stateMachine) { }

    public override IEnumerator Start()
    {
        gameStateMachine = stateMachine as GameStateMachine;

        player = gameStateMachine.Player;
        player.enabled = false;

        screens = gameStateMachine.Screens;
        screens.EnableLoseScreen();

        timer = gameStateMachine.Timer;
        int lastTimer = (int)timer.LastTimer;

        int countTry = gameStateMachine.CountTry;

        screens.LoseScreen.LastTimerText.text = $"Продолжительность последней попытки: {lastTimer}с.";
        screens.LoseScreen.CountTryText.text = $"Всего попыток: {countTry}";

        screens.LoseScreen.restartGameEvent += SetBeginGameState;

        yield break;
    }

    public override IEnumerator End()
    {
        player.enabled = true;

        screens.LoseScreen.restartGameEvent -= SetBeginGameState;

        yield break;
    }

    private void SetBeginGameState()
    {
        stateMachine.SetState(new InGameState(stateMachine));
    }
}