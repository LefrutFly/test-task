using UnityEngine;

[System.Serializable]
public class PlayerMove
{
    [SerializeField] private float velocityHorizontal;
    [SerializeField] private float velocityVertical;

    public float VelocityHorizontal => velocityHorizontal;
    public float VelocityVertical => velocityVertical;

    private Rigidbody2D playerRigidbody;
    private KeyCode upKey;

    public void Initialize(Rigidbody2D playerRigidbody, KeyCode upKey)
    {
        this.playerRigidbody = playerRigidbody;
        this.upKey = upKey;
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
        GoForward();
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

    private void GoForward()
    {
        playerRigidbody.velocity = new Vector2(velocityHorizontal * Time.deltaTime, playerRigidbody.velocity.y);
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