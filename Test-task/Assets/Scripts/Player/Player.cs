using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour
{
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {

        }
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
