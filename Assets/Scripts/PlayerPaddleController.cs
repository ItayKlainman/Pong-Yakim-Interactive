using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerPaddleController : BasePaddleController
{
    [SerializeField] private float speedMultiplier;
    
    private void FixedUpdate()
    {
        var input = Input.GetAxis("Vertical");
        var velocity = new Vector2(0, input * PADDLE_SPEED * speedMultiplier);
        var yVelocity = Mathf.Clamp(velocity.y, -MOVE_RANGE, MOVE_RANGE);
        
        MovePaddle(new Vector2(rb.velocity.x, yVelocity));
    }
}