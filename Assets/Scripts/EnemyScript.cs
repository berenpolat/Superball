using UnityEngine;
using System.Collections;

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
    public float enemySpeed;
    public Transform enemyStartPoint;
    private float originalSpeed;
    public static bool canShootBall = true;
    


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
        originalSpeed = enemySpeed;
        
      
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball") && EnmeySkills.canPowerShot == false)
        {
            ShootBall();
        }
    }

    private void Update()
    {
       
        
         TrackTheBall();
            
        
        if (enemySpeed < originalSpeed)
        {
            StartCoroutine(ResetSpeedAfterDelay());
            
        }
    }

    #endregion
    
    
    public void ShootBall()
    {
        Vector2 direction = (winFile.transform.position - transform.position).normalized;
        bm.Shoot(direction*ballSpeed);
    }
    void TrackTheBall()
    {
        Vector2 direction = (ball.transform.position - transform.position).normalized;
        
        rb.velocity = direction * enemySpeed;
    }


    private IEnumerator ResetSpeedAfterDelay() 
    {
       

        yield return new WaitForSeconds(3f); // 3 saniye bekle
            

        // Eğer enemySpeed hala originalSpeed'den düşükse, enemySpeed'i originalSpeed'e eşitle
        if (enemySpeed < originalSpeed)
        {
            enemySpeed = originalSpeed;
        }
    }

}