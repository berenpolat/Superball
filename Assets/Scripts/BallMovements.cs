using System;
using UnityEngine;

public class BallMovements : MonoBehaviour
{
    
    [SerializeField] private float force;
    [SerializeField] private Transform ballStartPoint;
    public GameManager gm;
    private Rigidbody2D rb;
    
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = ballStartPoint.position;
    }
    public void Shoot(Vector3 direction)
    {
        rb.AddForce(direction * force);
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
}
