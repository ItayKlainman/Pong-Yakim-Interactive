using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BasePaddleController : MonoBehaviour
{
    private Rigidbody2D rb;
    protected const float PADDLE_SPEED = 5f;
    protected const float MOVE_RANGE = 2.8f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    protected void MovePaddle(Vector2 velocity)
    {
        rb.velocity = velocity;
        
        var position = rb.position;
        var yPosClamped = Mathf.Clamp(position.y, -MOVE_RANGE, MOVE_RANGE);
        
        position = new Vector2(position.x, yPosClamped);
        rb.position = position;
    }
}
