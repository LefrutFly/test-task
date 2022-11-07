using System.Collections;
using UnityEngine;

public class BeginState : State
{
    private GameStateMachine gameStateMachine;
    private Player player;
    private Screens screens;

    public BeginState(StateMachine stateMachine) : base(stateMachine) { }

    public override IEnumerator Start()
    {
        gameStateMachine = stateMachine as GameStateMachine;
        player = gameStateMachine.Player;
        screens = gameStateMachine.Screens;

        DisablePlayer();
        EnableStartScreen();

        screens.StartScreen.startGameEvent += SetInGameState;

        yield break;
    }

    public override IEnumerator End()
    {
        screens.StartScreen.startGameEvent -= SetInGameState;

        yield break;
    }

    private void DisablePlayer()
    {
        player.gameObject.SetActive(false);
    }

    private void EnableStartScreen()
    {
        screens.EnableStartScreen();
    }

    private void SetInGameState()
    {
        stateMachine.SetState(new InGameState(stateMachine));
    }
}
