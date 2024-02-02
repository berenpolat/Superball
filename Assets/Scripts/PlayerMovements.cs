using System;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float speed;
    public VariableJoystick variableJoystick;
    private Rigidbody2D rb;
    private Vector3 input;
    private Vector2 direction;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void ShootButton()
    {
   
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach(Collider2D coll in colls)
        {
            if(coll.TryGetComponent(out BallMovements ball))
            {
                Vector3 dir = coll.transform.position - transform.position;
                ball.Shoot(dir);
                break;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    private void FixedUpdate()
    {
        direction = new Vector2(variableJoystick.Horizontal, variableJoystick.Vertical);
        direction.Normalize(); 
        rb.velocity = direction * speed;
    }
}