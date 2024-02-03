using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketScript : MonoBehaviour
{
    #region Script Instances

    [SerializeField] private GameManager gm;
    
    #endregion

    #region BuyButtons

    [SerializeField] private GameObject BuyButton1;
    [SerializeField] private GameObject BuyButton2;
    [SerializeField] private GameObject BuyButton3;

    #endregion

    #region Usebuttons

    [SerializeField] private GameObject UseButton1;
    [SerializeField] private GameObject UseButton2;
    [SerializeField] private GameObject UseButton3;

    #endregion
    
    public void BuyBall1()
    {
        if (gm.budget >= 100)
        {
            Destroy(BuyButton1);
            UseButton1.SetActive(true);
            gm.budget -= 100;
        }
    }
    public void BuyBall2()
    {
        if (gm.budget >= 200)
        {
            Destroy(BuyButton2);
            UseButton2.SetActive(true);
            gm.budget -= 200;
        }
    }
    public void BuyBall3()
    {
        if (gm.budget >= 300)
        {
            Destroy(BuyButton3);
            UseButton3.SetActive(true);
            gm.budget -= 300;
        }
    }
}
