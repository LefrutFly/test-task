using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour
{
    public event Action LoseGameEvent;

    [SerializeField] private PlayerMove move;

    [Inject] private PlayerControlSO playerControlSO;
    [Inject] private Timer timer;

    public PlayerMove Move => move;
    public Vector3 startPosiotion;

    private Rigidbody2D playerRigidbody;
    private KeyCode upKey;
    private float upVelocityVertical = 50;


    private void Awake()
    {
        InitializeRigidbody();
        InitializeUpKey();
        InitializeMove();
        InitializeStartPosiotion();
    }

    private void FixedUpdate()
    {
        move.Move(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            LoseGameEvent?.Invoke();
        }
    }

    private void OnEnable()
    {
        playerRigidbody.velocity = Vector3.zero;
        timer.secondsPassedEvent += UpVelocityVertical;
    }

    private void OnDisable()
    {
        playerRigidbody.velocity = Vector3.zero;
        timer.secondsPassedEvent -= UpVelocityVertical;
    }

    public void SetStartPosiotion()
    {
        transform.position = startPosiotion;
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

    private void InitializeStartPosiotion()
    {
        startPosiotion = transform.position;
    }

    private void UpVelocityVertical()
    {
        move.UpVelocityVertical(upVelocityVertical);
    }
}
