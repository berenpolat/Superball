using UnityEngine;

public class BallMovements : MonoBehaviour
{


    #region Script instances

    public GameManager gm;

    #endregion
   

    #region Ball variables

    private Rigidbody2D rb;
    [SerializeField] private float force;
    [SerializeField] private Transform ballStartPoint;

    #endregion

    #region unity Methods

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = ballStartPoint.position;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("WinColLeft"))
        {
            gm.enemyScore += 1;
        }
        if (other.gameObject.CompareTag("WinColRight"))
        {
            gm.playerScore += 1;
        }
        
    }
    
    #endregion
   
    public void Shoot(Vector3 direction)
    {
        rb.AddForce(direction * force);
    }

    
}
