using UnityEngine;

public class PlayerMovements : MonoBehaviour
{


    #region joyStick

    public VariableJoystick variableJoystick;

    #endregion
    

    #region Vectors

    private Vector3 input;
    private Vector2 direction;

    #endregion
    
    #region player variables
    
    [SerializeField] private float radius;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform startPoint;
    #endregion
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = startPoint.position;
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
    private void FixedUpdate()
    {
        direction = new Vector2(variableJoystick.Horizontal, variableJoystick.Vertical);
        direction.Normalize(); 
        rb.velocity = direction * speed;
    }
}