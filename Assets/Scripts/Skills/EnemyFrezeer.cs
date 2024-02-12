using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrezeer : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      PlayerMovements playerMovements = other.GetComponent<PlayerMovements>();

      if (playerMovements != null)
      {
        playerMovements.speed = 0;
      }
      
      Destroy((gameObject));
    }

    if (other.CompareTag("Border"))
    {
      Destroy(gameObject);
    }
      
  }
}
