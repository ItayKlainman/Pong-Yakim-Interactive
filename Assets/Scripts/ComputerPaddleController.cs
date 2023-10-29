using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ComputerPaddleController : BasePaddleController
{
    [SerializeField] private Transform ball;

    private void FixedUpdate()
    {
        if (ball.position.x > transform.position.x)
        {
            if (ball.position.y > transform.position.y)
            {
                MovePaddle(Vector2.up * PADDLE_SPEED);
            }
            else if (ball.position.y < transform.position.y)
            {
                MovePaddle(Vector2.down * PADDLE_SPEED);
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
        
        if (transform.position.y >= MOVE_RANGE)
        {
            MovePaddle(Vector2.zero);
        }

        var yVelocity = Mathf.Clamp(rb.velocity.y, -MOVE_RANGE, MOVE_RANGE);
        MovePaddle(new Vector2(rb.velocity.x, yVelocity));
    }
}