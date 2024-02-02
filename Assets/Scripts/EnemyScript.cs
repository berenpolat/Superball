using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float ballSpeed;
    [SerializeField] private float enemySpeed;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject winFile;
    private Rigidbody2D rb;
    [SerializeField] private BallMovements bm;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void TrackTheBall()
    {
        Vector2 direction = (ball.transform.position - transform.position).normalized;
        
        rb.velocity = direction * enemySpeed;
    }

    private void Update()
    {
        TrackTheBall();
    }

    private void ShootBall()
    {
        Vector2 direction = (winFile.transform.position - transform.position).normalized;
        bm.Shoot(direction*ballSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ShootBall();
        }
    }
}