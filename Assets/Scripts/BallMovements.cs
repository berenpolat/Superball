using UnityEngine;

public class BallMovements : MonoBehaviour
{
    
    [SerializeField] private float force;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Shoot(Vector3 direction)
    {
        rb.AddForce(direction * force);

    }
}
