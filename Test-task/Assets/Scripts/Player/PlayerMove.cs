using UnityEngine;

[System.Serializable]
public class PlayerMove
{
    [SerializeField] private float velocityVertical;

    public float VelocityVertical { get => velocityVertical; set => velocityVertical = value; }

    private Rigidbody2D playerRigidbody;
    private KeyCode upKey;
    private float startVelocityVertical;

    public void Initialize(Rigidbody2D playerRigidbody, KeyCode upKey)
    {
        startVelocityVertical = velocityVertical;
        this.playerRigidbody = playerRigidbody;
        this.upKey = upKey;
    }

    public void SetStartVelocityVertical()
    {
        velocityVertical = startVelocityVertical;
    }

    public void UpVelocityVertical(float up)
    {
        velocityVertical += up;
    }

    public void Move(object sender)
    {
        if (playerRigidbody == null)
        {
            Debug.LogError($"In {sender} PlayerRigidbody field not initialized! The Initialize method can help.");
            return;
        }

        if (upKey == KeyCode.None)
        {
            Debug.LogError($"In {sender} the Up key is not assigned! The Initialize method can help.");
            return;
        }

        if (isUpPressed())
        {
            GoUp();
        }
        else
        {
            GoDown();
        }
    }

    private bool isUpPressed()
    {
        if (Input.GetKey(upKey))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void GoUp()
    {
        playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, velocityVertical * Time.deltaTime);
    }

    private void GoDown()
    {
        playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, -velocityVertical * Time.deltaTime);
    }
}