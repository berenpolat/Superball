using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class BallMovements : MonoBehaviour
{
    #region Prefabs
    
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private GameObject GoalEffect;
    private GameObject GoalEffectInstance;
    
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
            GoalEffectInstance = Instantiate(GoalEffect, transform.position, quaternion.identity);
            Destroy(GoalEffectInstance, 1f);
            gm.enemyScore += 1;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0f;
            SetInitialPositions();
        }
        if (other.gameObject.CompareTag("WinColRight"))
        {
            GoalEffectInstance = Instantiate(GoalEffect, transform.position, quaternion.identity);
            Destroy(GoalEffectInstance, 1f);
            gm.playerScore += 1;
            SetInitialPositions();
            StartCoroutine(ShowGoalPanel());
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0f;
        }
    }

    private IEnumerator ShowGoalPanel()
    {
        goalPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
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
