using UnityEngine;

public class BasePaddleController : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected const float PADDLE_SPEED = 5f;
    protected const float MOVE_RANGE = 4f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    protected void MovePaddle(Vector2 velocity)
    {
        rb.velocity = velocity;
    }
}
