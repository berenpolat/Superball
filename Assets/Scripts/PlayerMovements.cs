using System;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform playerStartPoint;
    public VariableJoystick variableJoystick;
    private Rigidbody2D rb;
    private Vector3 input;
    private Vector2 direction;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = playerStartPoint.position;
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
        Vector2 targetDirection = new Vector2(variableJoystick.Horizontal, variableJoystick.Vertical);
        targetDirection.Normalize();

        // Dönüþ açýsýný hesapla
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Karakterin dönmesi
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * rotationSpeed);

        // Hareketi uygula
        rb.velocity = targetDirection * speed;
    }
}