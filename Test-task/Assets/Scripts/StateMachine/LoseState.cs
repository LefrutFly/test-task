using System.Collections;
using UnityEngine;

public class LoseState : State
{
    private GameStateMachine gameStateMachine;
    Player player;
    private Screens screens;

    public LoseState(StateMachine stateMachine) : base(stateMachine) { }

    public override IEnumerator Start()
    {
        Debug.Log("Lose");
        gameStateMachine = stateMachine as GameStateMachine;

        player = gameStateMachine.Player;
        player.enabled = false;

        screens = gameStateMachine.Screens;
        screens.EnableLoseScreen();

        yield break;
    }

    public override IEnumerator End()
    {
        player.enabled = true;

        yield break;
    }
}