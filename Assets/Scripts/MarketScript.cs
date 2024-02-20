using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketScript : MonoBehaviour
{
    [SerializeField] private GameObject marketPanel;
    [SerializeField] private GameObject ballSkinShopPanel;
    [SerializeField] private GameObject characterShopPanel;
    [SerializeField] private GameObject characterShopB;
    [SerializeField] private GameObject ballSkinShopB;
    [SerializeField] private Text buttonText1,buttonText2,buttonText3,buttonText4,buttonText5,buttonText6;
    #region Script Instances

    [SerializeField] private GameManager gm;
    
    #endregion

    #region BuyButtons

    public GameObject BuyButton1;
    public GameObject BuyButton2;
    public GameObject BuyButton3;
    public GameObject BuyButton4;
    public GameObject BuyButton5;
    public GameObject BuyButton6;

    #endregion
    

    private void Start()
    {
        UpdateButtonText("buttonText1", 100, buttonText1);
        UpdateButtonText("buttonText2", 200, buttonText2);
        UpdateButtonText("buttonText3", 300, buttonText3);
        UpdateButtonText("buttonText4", 100, buttonText4);
        UpdateButtonText("buttonText5", 200, buttonText5);
        UpdateButtonText("buttonText6", 300, buttonText6);
    }

    private void UpdateButtonText(string key, int cost, Text buttonText)
    {
        if (PlayerPrefs.GetInt(key, 0) == 1)
        {
            buttonText.text = "Use";
        }
        else
        {
            buttonText.text = PlayerPrefs.GetInt(key, cost).ToString();
        }
    }

    public void BuyBall1()
    {
        TryBuyItem("buttonText1", 100, buttonText1, 1);
    }

    public void BuyBall2()
    {
        TryBuyItem("buttonText2", 200, buttonText2, 1);
    }

    public void BuyBall3()
    {
        TryBuyItem("buttonText3", 300, buttonText3, 1);
    }

    public void BuyCar1()
    {
        TryBuyItem("buttonText4", 100, buttonText4, 1);
    }

    public void BuyCar2()
    {
        TryBuyItem("buttonText5", 200, buttonText5, 1);
    }

    public void BuyCar3()
    {
        TryBuyItem("buttonText6", 300, buttonText6, 1);
    }

    private void TryBuyItem(string key, int cost, Text buttonText, int value)
    {
        if (gm.budget >= cost && PlayerPrefs.GetInt(key, 0) != value)
        {
            buttonText.text = "Use";
            PlayerPrefs.SetInt(key, value);
            gm.budget -= cost;
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
