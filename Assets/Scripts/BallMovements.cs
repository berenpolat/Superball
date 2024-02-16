using System.Collections;
using UnityEngine;

public class BallMovements : MonoBehaviour
{
    #region Prefabs
    
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Enemy;
    
    #endregion

    #region Panels
    [SerializeField] private GameObject goalPanel;
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
            SetInitialPositions();
        }
        if (other.gameObject.CompareTag("WinColRight"))
        {
            gm.playerScore += 1;
            SetInitialPositions();
            StartCoroutine(ShowGoalPanel());
        }
    }

    private IEnumerator ShowGoalPanel()
    {
        goalPanel.SetActive(true);
        yield return new WaitForSeconds(2.3f);
        goalPanel.SetActive(false);
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
