using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    [SerializeField] private GameObject frezeeBullet;
    [SerializeField] private Transform FirePoint;
    [SerializeField] private float bulletSpeed;
    public bool Frezeer = false;

    Rigidbody2D rb;
    public float influenceRange;
    public float intensity;
    public float distanceToPlayer;
    Vector2 pullForce;
    public Transform ball;

    private void Start()
    {
        rb = ball.GetComponent<Rigidbody2D>();
    }

    public void FrezeerButton()
    {
       if(Frezeer == true)
       { 
          var Fbullet = Instantiate(frezeeBullet, FirePoint.position, FirePoint.rotation);
          Fbullet.GetComponent<Rigidbody2D>().velocity = FirePoint.up * bulletSpeed;
            Frezeer = false;
       }
    }
    public void FrezeerActive()
    {
        Frezeer = true;
    }
    public void PowerShoot()
    {
        distanceToPlayer = Vector2.Distance(ball.position, transform.position);
        if (distanceToPlayer <= influenceRange)
        {
            pullForce = (transform.position - ball.position).normalized / distanceToPlayer * intensity;
            rb.AddForce(pullForce, ForceMode2D.Force);
        }
    }
}
