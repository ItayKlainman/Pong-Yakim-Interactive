using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class BallController : MonoBehaviour
{
    [Range(-1, 1)]
    [SerializeField] private float xOffset;
    [SerializeField]private float speed;
    private Vector2 direction;
    private Rigidbody2D rb;

    private Action<ScoreSides> onGoalScore;

    public void InitBall(Action<ScoreSides> onScore)
    {
        onGoalScore = onScore;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        direction = Vector2.right;
    }

    public void LaunchBall()
    {
        var randomDirection = Random.Range(0, 2);
        direction = randomDirection == 0 ? Vector2.up : Vector2.down;
        xOffset = randomDirection == 0 ? xOffset * -1 : xOffset;
        direction.x = +xOffset;
        
        SetVelocity();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Wall":
                direction.y = -direction.y;
                break;
            case "Paddle":
                direction.x = -direction.x;
                break;
            case "Goal":
                UpdateScore(transform.position.x < 0 ? ScoreSides.Opponent : ScoreSides.Player);
                break;
        }

        SetVelocity();
    }

    private void SetVelocity()
    {
        rb.velocity = direction * speed;
    }

    private void UpdateScore(ScoreSides side)
    {
        transform.position = Vector3.zero;
        onGoalScore?.Invoke(side);
    }
}