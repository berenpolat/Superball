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

    public bool hasUsedBut1, hasUsedBut2, hasUsedBut3, hasUsedBut4, hasUsedBut5, hasUsedBut6;
    
    
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
        if (gm.budget >= 100 && PlayerPrefs.GetInt("buttonText1", 0) != 1)
        {
            buttonText1.text = "BOUGHT";
            PlayerPrefs.SetInt("buttonText1", 1);
            gm.budget -= 100;
            hasUsedBut1 = !hasUsedBut1;
        }
    }

    public void BuyBall2()
    {
        if (gm.budget >= 200 && PlayerPrefs.GetInt("buttonText2", 0) != 1)
        {
            buttonText1.text = "BOUGHT";
            PlayerPrefs.SetInt("buttonText2", 1);
            gm.budget -= 200;
            hasUsedBut2 = !hasUsedBut2;
        }
    }

    public void BuyBall3()
    {
        if (gm.budget >= 300 && PlayerPrefs.GetInt("buttonText3", 0) != 1)
        {
            buttonText1.text = "BOUGHT";
            PlayerPrefs.SetInt("buttonText3", 1);
            gm.budget -= 300;
            hasUsedBut3 = !hasUsedBut3;
        }
    }

    public void BuyCar1()
    {
        if (gm.budget >= 100 && PlayerPrefs.GetInt("buttonText4", 0) != 1)
        {
            buttonText1.text = "BOUGHT";
            PlayerPrefs.SetInt("buttonText4", 1);
            gm.budget -= 100;
            hasUsedBut4 = !hasUsedBut4;
        }
    }

    public void BuyCar2()
    {
        if (gm.budget >= 200 && PlayerPrefs.GetInt("buttonText5", 0) != 1)
        {
            buttonText1.text = "BOUGHT";
            PlayerPrefs.SetInt("buttonText5", 1);
            gm.budget -= 200;
            hasUsedBut5 = !hasUsedBut5;
        }
    }

    public void BuyCar3()
    {
        if (gm.budget >= 300 && PlayerPrefs.GetInt("buttonText6", 0) != 1)
        {
            buttonText1.text = "BOUGHT";
            PlayerPrefs.SetInt("buttonText6", 1);
            gm.budget -= 300;
            hasUsedBut6 = !hasUsedBut6;
        }
    }

    public void UseButton1()
    {
        if(hasUsedBut1)
            ballSpriteRenderer.sprite = ball1.sprite;
    }
    public void UseButton2()
    {
        if(hasUsedBut2)
            ballSpriteRenderer.sprite = ball2.sprite;
    }
    public void UseButton3()
    {
        if(hasUsedBut3)
            ballSpriteRenderer.sprite = ball3.sprite;
    }

    public void UseButton4()
    {
        if(hasUsedBut4)
            playerSpriteRenderer.sprite = car1.sprite;
    }
    
    public void UseButton5()
    {
        if(hasUsedBut5)
            playerSpriteRenderer.sprite = car2.sprite;
    }

    public void UseButton6()
    {
        if(hasUsedBut6)
            playerSpriteRenderer.sprite = car3.sprite;
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
