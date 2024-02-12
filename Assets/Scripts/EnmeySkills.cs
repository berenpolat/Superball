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
    [SerializeField] private float effectDuration;
    [SerializeField] private float bulletSpeed;
    private float nextActionTime = 0f;
    private GameObject currentEffect;
    #endregion
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            FireFrezeer();
            
            SpawnEffect();

            nextActionTime = Time.time + Random.Range(minDelay, maxDelay);
        }
        
        
    }

    void FireFrezeer()
    {
        GameObject bullet = Instantiate(FrezeerPrefab, FrezeerSpwnPoint.position, quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;
        Destroy(bullet, 5f);
        
    }

    void SpawnEffect()
    {
        GameObject effect = Instantiate(FrezeerEffect, transform.position, quaternion.identity);
        currentEffect = effect;
        Destroy(effect, effectDuration);
    }
    
}
