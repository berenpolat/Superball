using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkills : MonoBehaviour
{
    #region effectler
    [SerializeField] private GameObject frezeerPowerUpEffect;
    private GameObject FrezeerPowerUpInstance;
    public Vector2 offset;
    #endregion

    [SerializeField] GameObject player;
    [SerializeField] private GameObject frezeeBullet;
    [SerializeField] private Transform FirePoint;
    [SerializeField] private float bulletSpeed;
    public Button frezeerButton;
    public bool Frezeer = false;
    private bool frezeerUsed;

   
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        frezeerUsed = false;
    }

    public void FrezeerButton()
    {
       if(Frezeer == true)
       { 
          var Fbullet = Instantiate(frezeeBullet, FirePoint.position, FirePoint.rotation);
          Fbullet.GetComponent<Rigidbody2D>().velocity = FirePoint.up * bulletSpeed;
            Frezeer = false;
            frezeerUsed = true;
            if(frezeerUsed = true)
            {
                frezeerButton.interactable = false;
            }
            Destroy(FrezeerPowerUpInstance);
       }
    }
    public void FrezeerActive()
    {
        if(frezeerUsed == false)
        {
          Frezeer = true;
          FrezeerPowerUpInstance = Instantiate(frezeerPowerUpEffect, (Vector2)player.transform.position + offset, Quaternion.identity);
          FrezeerPowerUpInstance.transform.SetParent(player.transform);
          frezeerButton.interactable = true;
        }
    }
   
  
}
