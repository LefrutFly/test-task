using System;
using UnityEngine;
using TMPro;

public class LoseScreen : MonoBehaviour
{
    public event Action restartGameEvent;

    [SerializeField] private TMP_Text lastTimerText;
    [SerializeField] private TMP_Text countTry;

    public TMP_Text LastTimerText => lastTimerText;
    public TMP_Text CountTryText => countTry;

    public void RestartGame()
    {
        restartGameEvent?.Invoke();
    }
}