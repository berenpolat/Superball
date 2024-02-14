using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketScript : MonoBehaviour
{
    [SerializeField] private GameObject marketPanel;
    [SerializeField] private GameObject ballSkinShopPanel;
    [SerializeField] private GameObject characterShopPanel;
    [SerializeField] private GameObject characterShopB;
    [SerializeField] private GameObject ballSkinShopB;
    #region Script Instances

    [SerializeField] private GameManager gm;
    
    #endregion

    #region BuyButtons

    [SerializeField] private GameObject BuyButton1;
    [SerializeField] private GameObject BuyButton2;
    [SerializeField] private GameObject BuyButton3;
    [SerializeField] private GameObject BuyButton4;
    [SerializeField] private GameObject BuyButton5;
    [SerializeField] private GameObject BuyButton6;

    #endregion

    #region Usebuttons

    [SerializeField] private GameObject UseButton1;
    [SerializeField] private GameObject UseButton2;
    [SerializeField] private GameObject UseButton3;
    [SerializeField] private GameObject UseButton4;
    [SerializeField] private GameObject UseButton5;
    [SerializeField] private GameObject UseButton6;

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
    public void BuyCar1()
    {
        if (gm.budget >= 100)
        {
            Destroy(BuyButton4);
            UseButton4.SetActive(true);
            gm.budget -= 100;
        }
    }
    public void BuyCar2()
    {
        if (gm.budget >= 200)
        {
            Destroy(BuyButton5);
            UseButton5.SetActive(true);
            gm.budget -= 100;
        }
    }
    public void BuyCar3()
    {
        if (gm.budget >= 300)
        {
            Destroy(BuyButton6);
            UseButton6.SetActive(true);
            gm.budget -= 300;
        }
    }
    public void OpenMarket()
    {
        marketPanel.SetActive(true);
        ballSkinShopPanel.SetActive(true);  
        characterShopB.SetActive(true);
        characterShopPanel.SetActive(false);
        ballSkinShopB.SetActive(false);
    }
    public void GoToSkinShop()
    {
        ballSkinShopB.SetActive(false);
        characterShopPanel.SetActive(false);
        ballSkinShopPanel.SetActive(true);
        characterShopB.SetActive(true);
    }    
    public void GoToCharacterShop()
    {
        characterShopB.SetActive(false);
        ballSkinShopPanel.SetActive(false);
        characterShopPanel.SetActive(true);
        ballSkinShopB.SetActive(true);
        
    }    
    public void BackFromMarket()
    {
        marketPanel.SetActive(false);
    }

}
