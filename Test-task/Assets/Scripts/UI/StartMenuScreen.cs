using System;
using UnityEngine;

public class StartMenuScreen : MonoBehaviour
{
    public event Action startGameEvent;

    private Difficulty difficulty;

    public Difficulty Difficulty => difficulty;

    private void Awake()
    {
        ChooseNormal(true);
    }

    public void StartGame()
    {
        startGameEvent?.Invoke();
    }

    public void ChooseEasy(bool on)
    {
        if (on)
            difficulty = Difficulty.Easy;
    }

    public void ChooseNormal(bool on)
    {
        if (on)
            difficulty = Difficulty.Normal;
    }

    public void ChooseHard(bool on)
    {
        if (on)
            difficulty = Difficulty.Hard;
    }
}
