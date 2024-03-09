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

        // Dönüþ açýsýný hesapla
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Karakterin dönmesi
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * rotationSpeed);
        
        // Hareketi uygula
        rb.velocity = targetDirection * speed;

        if (speed < playerOriginalSpeed)
        {
            StartCoroutine(resetSpeed());
        }

        isMoving = rb.velocity.magnitude > 0.1f;
        animator.SetBool("isMoving", isMoving);
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