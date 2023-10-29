using UnityEngine;

public class PlayerPaddleController : BasePaddleController
{
    [SerializeField] private float speedMultiplier;
    
    private void FixedUpdate()
    {
        var input = Input.GetAxis("Vertical");
        var velocity = new Vector2(0, input * PADDLE_SPEED * speedMultiplier);

        MovePaddle(velocity);
    }
}