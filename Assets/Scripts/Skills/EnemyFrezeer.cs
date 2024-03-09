
using Unity.Mathematics;
using UnityEngine;

public class EnemyFrezeer : MonoBehaviour
{
  [SerializeField] private GameObject FrezeerBlowUp;
  private GameObject FrezeerBlowUpInstance;
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      PlayerMovements playerMovements = other.GetComponent<PlayerMovements>();

      if (playerMovements != null)
      {
        playerMovements.speed = 0;
      }

      FrezeerBlowUpInstance = Instantiate(FrezeerBlowUp, transform.position, quaternion.identity);
      Destroy(FrezeerBlowUpInstance, 1f);
      Destroy((gameObject));
    }

    if (other.CompareTag("Border"))
    {
      Destroy(gameObject);
    }
      
  }
}
