using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableTerrain : MonoBehaviour
{
    [SerializeField] private float velocityHorizontal1;
    [SerializeField] private float velocityHorizontal2;
    [SerializeField] private float velocityHorizontal3;
    [Space]
    [SerializeField] private float currentVelocityHorizontal;
    [Space]
    [SerializeField] private Vector3 startposition;

    private bool isMoving = true;

    private void Awake()
    {
        ResetPosiotion();
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            transform.Translate(new Vector3(-currentVelocityHorizontal, 0, 0) * Time.deltaTime);
        }
    }

    public void ChooseDifficulty(Difficulty difficulty)
    {
        if (difficulty == Difficulty.Easy) currentVelocityHorizontal = velocityHorizontal1;
        else if (difficulty == Difficulty.Normal) currentVelocityHorizontal = velocityHorizontal2;
        else if (difficulty == Difficulty.Hard) currentVelocityHorizontal = velocityHorizontal3;
        else currentVelocityHorizontal = velocityHorizontal2;
    }

    public void StopMove()
    {
        isMoving = false;
    }

    public void StartMove()
    {
        isMoving = true;
    }

    public void ResetPosiotion()
    {
        transform.position = startposition;
    }
}
