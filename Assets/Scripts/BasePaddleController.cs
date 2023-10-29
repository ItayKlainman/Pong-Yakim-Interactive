using UnityEngine;

public class BasePaddleController : MonoBehaviour
{
    protected Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    protected void MovePaddle(Vector2 velocity)
    {
        rb.velocity = velocity;
    }
}
