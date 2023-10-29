using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ComputerPaddleController : BasePaddleController
{
    [SerializeField] private Transform ball;
    [SerializeField] private float paddleSpeed = 5f;
    [SerializeField] private float moveRange;
    
    private void FixedUpdate()
    {
        if (ball.position.x > transform.position.x)
        {
            if (ball.position.y > transform.position.y)
            {
                MovePaddle(Vector2.up * paddleSpeed);
            }
            else if (ball.position.y < transform.position.y)
            {
                MovePaddle(Vector2.down * paddleSpeed);
            }
            else
            {
                MovePaddle(Vector2.zero);
            }
        }
        else
        {
            MovePaddle(Vector2.zero);
        }
        
        if (transform.position.y >= moveRange)
        {
            MovePaddle(Vector2.zero);
        }

        var yVelocity = Mathf.Clamp(rb.velocity.y, -moveRange, moveRange);
        MovePaddle(new Vector2(rb.velocity.x, yVelocity));
    }
}