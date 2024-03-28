using System.Collections;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    #region Joytick

    public VariableJoystick variableJoystick;

    #endregion

    #region Player variables

    [SerializeField] private float radius;
    [SerializeField] private float rotationSpeed;
    public Transform playerStartPoint;
    public  float speed;
    private float playerOriginalSpeed;
    public static bool CanShoot;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isMoving;
    
    #endregion

    #region Vectors

    private Vector3 input;
    private Vector2 direction;

    #endregion

    #region Unity Methods

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = playerStartPoint.position;
        CanShoot = true;
        playerOriginalSpeed = speed;
        isMoving = false;
        
    }
    private void FixedUpdate()
    {
        Vector2 targetDirection = new Vector2(variableJoystick.Horizontal, variableJoystick.Vertical);
        targetDirection.Normalize();

        // Check if the player is moving
        if (targetDirection.magnitude > 0.1f)
        {
            // Calculate the angle based on the direction of movement
            float angle = Vector2.SignedAngle(Vector2.right, targetDirection);

            // Rotate the player
           // transform.rotation = Quaternion.Euler(0, 0, angle);

            // Apply movement
            rb.velocity = targetDirection * speed;
        }
        else
        {
            // Stop the player if not moving
            rb.velocity = Vector2.zero;
        }

        if (speed < playerOriginalSpeed)
        {
            StartCoroutine(resetSpeed());
        }
        if (targetDirection.x < 0) // Moving left
        {
            transform.localScale = new Vector2(-1f, transform.localScale.y);
        }
        else if (targetDirection.x > 0) // Moving right
        {
            transform.localScale = new Vector2(1f, transform.localScale.y);
        }

        isMoving = rb.velocity.magnitude > 0.1f;
    }


    #endregion

    public void ShootButton()
    {
      if(CanShoot == true)
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
    }
    public  void powerShot()
    {
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D coll in colls)
        {
            if (coll.TryGetComponent(out BallMovements ball))
            {
                Vector3 dir = coll.transform.position - transform.position;
                ball.PowerShoot(dir);
                break;
                
            }
        }
    }

    private IEnumerator resetSpeed()
    {
        yield return new WaitForSeconds(3f);

        if (speed < playerOriginalSpeed)
        {
            speed = playerOriginalSpeed;
        }
    }
}