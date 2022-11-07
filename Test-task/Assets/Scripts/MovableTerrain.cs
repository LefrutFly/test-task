using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

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
    [SerializeField] private Vector3 startPositionWalls_1;
    [SerializeField] private Vector3 startPositionWalls_2;
    [SerializeField] private float firstPointToSpawnWalls;
    [SerializeField] private float secondPointToSpawnWalls;
    [Space]
    [SerializeField] private Transform firstPoint;
    [SerializeField] private Transform secondPoint;
    [Space]
    [SerializeField] private GameObject oneWallPrefabe;
    [SerializeField] private float TopHightToSpawn;
    [SerializeField] private float BotHightToSpawn;

    [Inject] private MapSO mapSO;

    private bool isMoving = true;
    private bool isCurrentW1 = true;
    private bool isCurrentW2 = false;

    private List<GameObject> oneWalls_1 = new List<GameObject>();
    private List<GameObject> oneWalls_2 = new List<GameObject>();


    private void FixedUpdate()
    {
        MoveWalls();
        MoveTerrain();
    }

    private void SpawnWalls()
    {
        for (float x = firstPointToSpawnWalls; x <= secondPointToSpawnWalls; x += mapSO.RangeBetweenWalls)
        {
            Vector2 pointToSpawn = new Vector2(0, 0);
            pointToSpawn.x = x;
            pointToSpawn.y = Random.Range(BotHightToSpawn, TopHightToSpawn);

            GameObject wall = Instantiate(oneWallPrefabe, pointToSpawn, Quaternion.identity);

            if (isCurrentW1)
            {
                wall.transform.SetParent(transform);
                oneWalls_1.Add(wall);
            }
            else if (isCurrentW2)
            {
                wall.transform.SetParent(transform);
                oneWalls_2.Add(wall);
            }
        }
    }

    private void MoveWalls()
    {
        if (isMoving)
        {
            if (isCurrentW1)
            {
                if (walls_1.transform.position.x <= firstPoint.transform.position.x)
                {
                    walls_2.transform.position = new Vector3(secondPoint.position.x, 0, 0);
                    isCurrentW1 = false;
                    isCurrentW2 = true;
                    DeleteOneWalls_2();
                    SpawnWalls();
                }
            }
            if (isCurrentW2)
            {
                if (walls_2.transform.position.x <= firstPoint.transform.position.x)
                {
                    walls_1.transform.position = new Vector3(secondPoint.position.x, 0, 0);
                    isCurrentW1 = true;
                    isCurrentW2 = false;
                    DeleteOneWalls_1();
                    SpawnWalls();
                }
            }
        }
    }

    private void MoveTerrain()
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
        walls_1.transform.position = startPositionWalls_1;
        walls_2.transform.position = startPositionWalls_2;
        DeleteOneWalls_1();
        DeleteOneWalls_2();
        isCurrentW1 = true;
        isCurrentW2 = false;
        SpawnWalls();
    }

    private void DeleteOneWalls_1()
    {
        foreach (var w in oneWalls_1)
        {
            Destroy(w);
        }
        oneWalls_1.Clear();
    }

    private void DeleteOneWalls_2()
    {
        foreach (var w in oneWalls_2)
        {
            Destroy(w);
        }
        oneWalls_2.Clear();
    }
}
