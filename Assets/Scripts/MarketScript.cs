using System;using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketScript : MonoBehaviour
{
    [SerializeField] private GameObject marketPanel;
    [SerializeField] private GameObject ballSkinShopPanel;
    [SerializeField] private GameObject characterShopPanel;
    [SerializeField] private GameObject characterShopB;
    [SerializeField] private GameObject ballSkinShopB;
    [SerializeField] private Text buttonText1, buttonText2, buttonText3, buttonText4, buttonText5, buttonText6;
    
    public SpriteRenderer ballSpriteRenderer,playerSpriteRenderer;
    
    
    public Image ball1;
    public Image ball2;
    public Image ball3;
    public Image car1;
    public Image car2;
    public Image car3;

    #region UseButtons

    public GameObject UseButtonGo1;
    public GameObject UseButtonGo2;
    public GameObject UseButtonGo3;
    public GameObject UseButtonGo4;
    public GameObject UseButtonGo5;
    public GameObject UseButtonGo6;
    

    #endregion

    #region Script Instances

    [SerializeField] private GameManager gm;

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
    
    private void Update()
    {
        PlayerPrefs.SetInt("ball1", PlayerPrefs.GetInt("ball1", 0));
        PlayerPrefs.SetInt("ball2", PlayerPrefs.GetInt("ball2", 0));
        PlayerPrefs.SetInt("ball3", PlayerPrefs.GetInt("ball3", 0));
        PlayerPrefs.SetInt("car1", PlayerPrefs.GetInt("car1", 0));
        PlayerPrefs.SetInt("car2", PlayerPrefs.GetInt("car2", 0));
        PlayerPrefs.SetInt("car3", PlayerPrefs.GetInt("car3", 0));
    }


    private void UpdateButtonText(string key, int cost, Text buttonText)
    {
        if (PlayerPrefs.GetInt(key, 0) == 1)
        {
            buttonText.text = "BOUGHT";
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

    public void UseButton1()
    {
        ballSpriteRenderer.sprite = ball1.sprite;
    }
    public void UseButton2()
    {
        ballSpriteRenderer.sprite = ball2.sprite;
    }
    public void UseButton3()
    {
        ballSpriteRenderer.sprite = ball3.sprite;
    }

    public void UseButton4()
    {
        playerSpriteRenderer.sprite = ball1.sprite;
    }
    
    public void UseButton5()
    {
        playerSpriteRenderer.sprite = car2.sprite;
    }

    public void UseButton6()
    {
        playerSpriteRenderer.sprite = car3.sprite;
    }
    
    private void TryBuyItem(string key, int cost, Text buttonText, int value)
    {
        if (gm.budget >= cost && PlayerPrefs.GetInt(key, 0) != value)
        {
            buttonText.text = "BOUGHT";
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
