using System;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class BallMovements : MonoBehaviour
{
    #region Prefabs
    
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Enemy;
    
    #endregion


    #region Script instances

    public GameManager gm;
    public PlayerMovements pm;
    public EnemyScript es;

    #endregion
   

    #region Ball variables

    private Rigidbody2D rb;
    [SerializeField] private float force;
    [SerializeField] private float PowerShotForce;
    public Transform ballStartPoint;
    public static bool isPowerShotActive = true;
    public Color newColor;
    

    #endregion
    #region unity Methods


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = ballStartPoint.position;
      
    }

    private void Update()
    {
        if (isPowerShotActive)
        {
            TrailRenderer trailRenderer = GetComponent<TrailRenderer>();

            // Eğer Trail Renderer bileşeni varsa, rengini değiştir
            if (trailRenderer != null)
            {
                
                
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("WinColLeft"))
        {
            gm.enemyScore += 1;
            SetInitialPositions();
        }
        if (other.gameObject.CompareTag("WinColRight"))
        {
            gm.playerScore += 1;
            SetInitialPositions();
        }
        
    }
    
    #endregion
   
    public void Shoot(Vector3 direction)
    {
        rb.AddForce(direction * force);
    }
    public void PowerShoot(Vector3 direction)
    {
        rb.AddForce(direction * PowerShotForce);
    }

    private void SetInitialPositions()
    {
        Player.transform.position = pm.playerStartPoint.position;
        Enemy.transform.position = es.enemyStartPoint.position;
        transform.position = ballStartPoint.position;
    }
    
}
