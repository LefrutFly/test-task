using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour
{
    public event Action LoseGameEvent;

    [SerializeField] private PlayerMove move;

    [Inject] private PlayerControlSO playerControlSO;

    public PlayerMove Move => move;

    private Rigidbody2D playerRigidbody;
    private KeyCode upKey;


    private void Awake()
    {
        InitializeRigidbody();
        InitializeUpKey();
        InitializeMove();
    }

    private void Update()
    {
        move.Move(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            LoseGameEvent?.Invoke();
        }
    }

    private void OnEnable()
    {
        playerRigidbody.velocity = Vector3.zero;
    }

    private void OnDisable()
    {
        playerRigidbody.velocity = Vector3.zero;
    }

    private void InitializeRigidbody()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void InitializeUpKey()
    {
        upKey = playerControlSO.Up;
    }

    private void InitializeMove()
    {
        move.Initialize(playerRigidbody, upKey);
    }
}
