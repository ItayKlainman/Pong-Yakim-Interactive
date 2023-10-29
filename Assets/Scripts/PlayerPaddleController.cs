using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerPaddleController : BasePaddleController
{
    public float paddleSpeed = 5f;
    public float moveRange = 4f;
    
    private void FixedUpdate()
    {
        var input = Input.GetAxis("Vertical");
        var velocity = new Vector2(0, input * paddleSpeed);
        var yVelocity = Mathf.Clamp(velocity.y, -moveRange, moveRange);
        
        MovePaddle(new Vector2(rb.velocity.x, yVelocity));
    }
}