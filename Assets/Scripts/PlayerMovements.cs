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
    
    #endregion

    #region Vectors

    private Vector3 input;
    private Vector2 direction;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = playerStartPoint.position;
        CanShoot = true;
        playerOriginalSpeed = speed;
    }
    private void FixedUpdate()
    {
        Vector2 targetDirection = new Vector2(variableJoystick.Horizontal, variableJoystick.Vertical);
        targetDirection.Normalize();

        // Dönüþ açýsýný hesapla
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

        // Karakterin dönme açýsýný sýnýrla
        if (targetDirection.x > 0 && targetDirection.y > 0)
        {
            // Sað yukarý
            angle = Mathf.Clamp(angle, -45f, 45f);
        }
        else if (targetDirection.x > 0 && targetDirection.y < 0)
        {
            // Sað aþaðý
            angle = Mathf.Clamp(angle, -45f, -45);
        }
        else if (targetDirection.x < 0)
        {
            // Sol
            angle = Mathf.Clamp(angle, -45, -45f);
        }

        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Karakterin dönmesi
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * rotationSpeed);

        // Sprite'ýn dönüþünü ayarla
        if (variableJoystick.Horizontal < 0)
        {
            // Karakter sola hareket ediyorsa
            transform.localScale = new Vector3(-1, 1, 1); // Sprite'ý ters çevir
        }
        else if (variableJoystick.Horizontal > 0)
        {
            // Karakter saða hareket ediyorsa
            transform.localScale = new Vector3(1, 1, 1); // Normal dönüþü ayarla
        }

        // Hareketi uygula
        rb.velocity = targetDirection * speed;

        if (speed < playerOriginalSpeed)
        {
            StartCoroutine(resetSpeed());
        }
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