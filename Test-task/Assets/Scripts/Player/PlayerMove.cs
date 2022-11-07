using UnityEngine;

[System.Serializable]
public class PlayerMove
{
    [SerializeField] private float velocityHorizontal1;
    [SerializeField] private float velocityHorizontal2;
    [SerializeField] private float velocityHorizontal3;
    [Space]
    [SerializeField] private float velocityVertical;

    public float VelocityHorizontal1 => velocityHorizontal1;
    public float VelocityHorizontal2 => velocityHorizontal2;
    public float VelocityHorizontal3 => velocityHorizontal3;
    public float VelocityVertical { get => velocityVertical; set => velocityVertical = value; }

    private float currentVelocityHorizontal;
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

    public void ChooseDifficulty(Difficulty difficulty)
    {
        if (difficulty == Difficulty.Easy) currentVelocityHorizontal = velocityHorizontal1;
        else if (difficulty == Difficulty.Normal) currentVelocityHorizontal = velocityHorizontal2;
        else if (difficulty == Difficulty.Hard) currentVelocityHorizontal = velocityHorizontal3;
        else currentVelocityHorizontal = velocityHorizontal2;
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

        if (currentVelocityHorizontal == 0) 
        {
            Debug.LogError($"In {sender} currentVelocityHorizontal = 0! The ChooseDifficulty method can help.");
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
        playerRigidbody.velocity = new Vector2(currentVelocityHorizontal * Time.deltaTime, playerRigidbody.velocity.y);
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