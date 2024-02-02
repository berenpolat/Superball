using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frezeer : MonoBehaviour
{
    

    void OnTriggerEnter2D(Collider2D other)
    {
        // Diðer obje "Enemy" tag'ine sahip mi kontrol et
        if (other.CompareTag("Enemy"))
        {
            // Eðer çarptýðýmýz obje "Enemy" tag'ine sahip ise, EnemyScript bileþenini al
            EnemyScript enemyScript = other.GetComponent<EnemyScript>();

            // EnemyScript bulundu mu kontrol et
            if (enemyScript != null)
            {
                // Eðer enemyScript deðiþkeni boþ deðilse, enemySpeed'i 0 yap
                enemyScript.enemySpeed = 0;
                
            }
            Destroy(gameObject);
        }
    }
}
