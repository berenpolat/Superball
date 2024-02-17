using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnmeySkills : MonoBehaviour
{
    #region  Frezeerdegerleri
    [SerializeField] private GameObject FrezeerPrefab;
    [SerializeField] private GameObject FrezeerEffect;
    [SerializeField] private Transform FrezeerSpwnPoint;
    [SerializeField] private float minDelay;
    [SerializeField] private float maxDelay;
    [SerializeField] private float bulletSpeed;
    private float nextActionTime = 0f;
    private GameObject currentEffect;
    private GameObject Enemyy;
    private GameObject FrezeerEffectInstance;
    public static bool EnemyHaveFrezeer;
    #endregion

    #region enemyPowerShot
    [SerializeField] private float minPDelay;
    [SerializeField] private float maxPDelay;
    [SerializeField] private float ballPSpeed;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject winFile;
    [SerializeField] private GameObject powerShotEffect;
    [SerializeField] private BallMovements bm;
    private GameObject powerShotEffectInstance;
    
    public static bool enemyHavePowerShot;
    public static bool canPowerShot = false;
    private float nextPActionTime = 0f;
    #endregion
  

    private void Start()
    {
        Enemyy = GameObject.FindGameObjectWithTag("Enemy");
        
    }

    void Update()
    {
        if (Time.time > nextActionTime && EnemyHaveFrezeer)
        {
            FireFrezeer();
            nextActionTime = Time.time + Random.Range(minDelay, maxDelay);
        }

        
        if (Time.time > nextPActionTime && enemyHavePowerShot)
        {
            canPowerShot = true;
            nextPActionTime = Time.time + Random.Range(minPDelay, maxPDelay);
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball") && canPowerShot && enemyHavePowerShot)
        {
            Vector2 direction = (winFile.transform.position - transform.position).normalized;
            bm.Shoot(direction*ballPSpeed);
            canPowerShot = false;
            powerShotEffectInstance = Instantiate(powerShotEffect, transform.position, quaternion.identity);
            powerShotEffectInstance.transform.SetParent(Enemyy.transform);
            Destroy(powerShotEffectInstance, .5f);

        }
    }
    
    void FireFrezeer()
    {
        FrezeerEffectInstance = Instantiate(FrezeerEffect, transform.position, quaternion.identity);
        FrezeerEffectInstance.transform.SetParent(Enemyy.transform);

        StartCoroutine(Frezee());

    }

   

    private IEnumerator Frezee()
    {
        yield return new WaitForSeconds(1f);
        
        GameObject bullet = Instantiate(FrezeerPrefab, FrezeerSpwnPoint.position, quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        
        Vector2 direction = (GameObject.FindGameObjectWithTag("Player").transform.position - FrezeerSpwnPoint.position).normalized;
        rb.velocity = direction * bulletSpeed;
        Destroy(bullet, 5f);
        Destroy(FrezeerEffectInstance);
        
    }


}
