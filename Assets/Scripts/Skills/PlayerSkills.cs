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

    #region Frezeer

    [SerializeField] GameObject player;
    [SerializeField] private GameObject frezeeBullet;
    [SerializeField] private Transform FirePoint;
    [SerializeField] private float bulletSpeed;
    public Button frezeerButton;
    public bool Frezeer = false;
    private bool frezeerUsed;

    #endregion

    #region PowerShoot

    [SerializeField] private Transform grabPoint;
    [SerializeField] private Transform rayPoint;
    [SerializeField] private float rayDistance;
    [SerializeField] private float circleRadius = 1f;
    BallMovements ballMovementsScript;
    private GameObject grabbedObject;
    private int layerIndex;

    #endregion

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        layerIndex = LayerMask.NameToLayer("ball");
        frezeerUsed = false;
    }
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);

        if (Input.GetKey(KeyCode.K))
        {
            grabbedObject = hitInfo.collider.gameObject;
            grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
            grabbedObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            grabbedObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            grabbedObject.transform.position = grabPoint.position;
            grabbedObject.transform.SetParent(transform);
           
        }
        else if (Input.GetKeyUp(KeyCode.K))
        {
           
            grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
            grabbedObject.transform.SetParent(null);
            grabbedObject = null;
            
        }
    }

    public void FrezeerButton()
    {
        if (Frezeer == true)
        {
            var Fbullet = Instantiate(frezeeBullet, FirePoint.position, FirePoint.rotation);
            Fbullet.GetComponent<Rigidbody2D>().velocity = FirePoint.up * bulletSpeed;
            Frezeer = false;
            frezeerUsed = true;
            if (frezeerUsed = true)
            {
                frezeerButton.interactable = false;
            }
            Destroy(FrezeerPowerUpInstance);
        }
    }
    public void FrezeerActive()
    {
        if (frezeerUsed == false)
        {
            Frezeer = true;
            FrezeerPowerUpInstance = Instantiate(frezeerPowerUpEffect, (Vector2)player.transform.position + offset, Quaternion.identity);
            FrezeerPowerUpInstance.transform.SetParent(player.transform);
            frezeerButton.interactable = true;
        }
    }
    void OnDrawGizmos()
    {
        // Gizmos ile CircleCast'in alanını çizelim.
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(rayPoint.position + (Vector3)transform.right * rayDistance, circleRadius);
    }



}
