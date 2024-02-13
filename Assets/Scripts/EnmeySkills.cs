using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnmeySkills : MonoBehaviour
{
    #region  değerler
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

    private void Start()
    {
        Enemyy = GameObject.FindGameObjectWithTag("Enemy");
    }

    void Update()
    {
        if (Time.time > nextActionTime)
        {
            FireFrezeer();
            
           

            nextActionTime = Time.time + Random.Range(minDelay, maxDelay);
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
