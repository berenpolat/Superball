using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    [SerializeField] private GameObject frezeeBullet;
    [SerializeField] private Transform FirePoint;
    [SerializeField] private float bulletSpeed;

    public bool Frezeer = false;

    public void FrezeerButton()
    {
       if(Frezeer == true)
        { 
          var Fbullet = Instantiate(frezeeBullet, FirePoint.position, FirePoint.rotation);
          Fbullet.GetComponent<Rigidbody2D>().velocity = FirePoint.up * bulletSpeed;
        }
    }
    public void FrezeerActive()
    {
        Frezeer = true;
    }
}
