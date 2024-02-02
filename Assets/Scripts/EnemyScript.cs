using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    #region File Transform

    [SerializeField] private GameObject winFile;

    #endregion
 
    
    #region scripts instances

    [SerializeField] private BallMovements bm;


    #endregion

    #region Enemy variables

    private Rigidbody2D rb;
    [SerializeField] private float enemySpeed;
    
    #endregion

    #region Ball variables

    [SerializeField] private float ballSpeed;
    [SerializeField] private GameObject ball;

    #endregion
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