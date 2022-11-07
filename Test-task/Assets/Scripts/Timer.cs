using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Timer : MonoBehaviour
{
    public event Action secondsPassedEvent;

    [SerializeField] private float currentTimer = 0;
    [SerializeField] private float lastTimer = 0;

    [Inject] private WaitSecondsSO waitSecondsSO;

    public float CurrentTimer => currentTimer;
    public float LastTimer => lastTimer;

    private Coroutine coroutine;
    private float waitSeconds;


    private void Awake()
    {
        waitSeconds = waitSecondsSO.Seconds;
    }

    private void Update()
    {
        currentTimer += Time.deltaTime;
    }

    public void ResetTimer()
    {
        lastTimer = currentTimer;
        currentTimer = 0;
    }

    public void ResetCurrentTimer()
    {
        currentTimer = 0;
    }

    public void RestartLastTimer()
    {
        lastTimer = 0;
        if (coroutine != null) 
        {
            StopCoroutine(coroutine); 
            coroutine = null;
        }
        coroutine = StartCoroutine(enumerator());
    }

    private IEnumerator enumerator()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitSeconds);
            secondsPassedEvent?.Invoke();
        }
    }
}
