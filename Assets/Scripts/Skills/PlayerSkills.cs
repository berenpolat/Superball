using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    //effectler
    [SerializeField] private GameObject frezeerPowerUpEffect;
    private GameObject FrezeerPowerUpInstance;
    [SerializeField] GameObject player;
    [SerializeField] private GameObject frezeeBullet;
    [SerializeField] private Transform FirePoint;
    [SerializeField] private float bulletSpeed;
    public bool Frezeer = false;
    public Vector2 offset;

   
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void FrezeerButton()
    {
       if(Frezeer == true)
       { 
          var Fbullet = Instantiate(frezeeBullet, FirePoint.position, FirePoint.rotation);
          Fbullet.GetComponent<Rigidbody2D>().velocity = FirePoint.up * bulletSpeed;
            Frezeer = false;
            Destroy(FrezeerPowerUpInstance);
       }
    }
    public void FrezeerActive()
    {
        Frezeer = true;
        FrezeerPowerUpInstance = Instantiate(frezeerPowerUpEffect, (Vector2)player.transform.position + offset, Quaternion.identity);
        FrezeerPowerUpInstance.transform.SetParent(player.transform);
    }
   
  
}
