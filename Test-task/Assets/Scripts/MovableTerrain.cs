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
    [Space]
    [SerializeField] private GameObject walls_1;
    [SerializeField] private GameObject walls_2;
    [Space]
    [SerializeField] private Transform firstPoint;
    [SerializeField] private Transform secondPoint;

    private bool isMoving = true;
    private bool isCurrentW1 = true;
    private bool isCurrentW2 = false;


    private void Awake()
    {
        ResetPosiotion();
    }

    private void FixedUpdate()
    {
        if (isCurrentW1)
        {
            if (walls_1.transform.position.x <= firstPoint.transform.position.x)
            {
                walls_2.transform.position = new Vector3(secondPoint.position.x, 0, 0);
                isCurrentW1 = false;
                isCurrentW2 = true;
            }
        }
        if (isCurrentW2)
        {
            if (walls_2.transform.position.x <= firstPoint.transform.position.x)
            {
                walls_1.transform.position = new Vector3(secondPoint.position.x, 0, 0);
                isCurrentW1 = true;
                isCurrentW2 = false;
            }
        }

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
