using Unity.Mathematics;
using UnityEngine;

public class Frezeer : MonoBehaviour
{
    [SerializeField] private GameObject FrezeerBlowUp;
    private GameObject FrezeerBlowUpInstance;
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

            FrezeerBlowUpInstance = Instantiate(FrezeerBlowUp, transform.position, quaternion.identity);
            Destroy(FrezeerBlowUpInstance, 1f);
            Destroy(gameObject);
        }
        if(other.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }
}
