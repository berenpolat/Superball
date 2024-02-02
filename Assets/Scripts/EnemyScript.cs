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
    public Transform enemyStartPoint;
    
    #endregion

    #region Ball variables

    [SerializeField] private float ballSpeed;
    [SerializeField] private GameObject ball;

    #endregion


    #region Unity Methods

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = enemyStartPoint.position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ShootBall();
        }
    }

    private void Update()
    {
        TrackTheBall();
    }

    #endregion
    
    
    private void ShootBall()
    {
        Vector2 direction = (winFile.transform.position - transform.position).normalized;
        bm.Shoot(direction*ballSpeed);
    }
    void TrackTheBall()
    {
        Vector2 direction = (ball.transform.position - transform.position).normalized;
        
        rb.velocity = direction * enemySpeed;
    }

}