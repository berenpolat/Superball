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

    public string hasUsedBut1, hasUsedBut2, hasUsedBut3, hasUsedBut4, hasUsedBut5, hasUsedBut6;
    public int lastUsedCar; 
    public int lastUsedBall;
    
    public Sprite ball1;
    public Sprite ball2;
    public Sprite ball3;
    public Sprite car1;
    public Sprite car2;
    public Sprite car3;
    

    #region Script Instances

    [SerializeField] private GameManager gm;

    #endregion

    private void Start()
    {
        
        lastUsedBall= PlayerPrefs.GetInt("lastUsedCar");
        lastUsedBall = PlayerPrefs.GetInt("lastUsedBall");

        hasUsedBut1 = PlayerPrefs.GetString("hasUsedBut1");
        hasUsedBut2 = PlayerPrefs.GetString("hasUsedBut2");
        hasUsedBut3 = PlayerPrefs.GetString("hasUsedBut3");
        hasUsedBut4 = PlayerPrefs.GetString("hasUsedBut4");
        hasUsedBut5 = PlayerPrefs.GetString("hasUsedBut5");
        hasUsedBut6 = PlayerPrefs.GetString("hasUsedBut6");
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
            hasUsedBut1 = "YES";
            PlayerPrefs.SetString("hasUsedBut1",hasUsedBut1);
        }
    }

    public void BuyBall2()
    {
        if (gm.budget >= 200 && PlayerPrefs.GetInt("buttonText2", 0) != 1)
        {
            buttonText2.text = "BOUGHT";
            PlayerPrefs.SetInt("buttonText2", 1);
            gm.budget -= 200;
            hasUsedBut2 ="YES";
            PlayerPrefs.SetString("hasUsedBut2",hasUsedBut2);
        }
    }

    public void BuyBall3()
    {
        if (gm.budget >= 300 && PlayerPrefs.GetInt("buttonText3", 0) != 1)
        {
            buttonText3.text = "BOUGHT";
            PlayerPrefs.SetInt("buttonText3", 1);
            gm.budget -= 300;
            hasUsedBut3 = "YES";
            PlayerPrefs.SetString("hasUsedBut3",hasUsedBut3);
        }
    }

    public void BuyCar1()
    {
        if (gm.budget >= 100 && PlayerPrefs.GetInt("buttonText4", 0) != 1)
        {
            buttonText4.text = "BOUGHT";
            PlayerPrefs.SetInt("buttonText4", 1);
            gm.budget -= 100;
            hasUsedBut4 ="YES";
            PlayerPrefs.SetString("hasUsedBut4",hasUsedBut4);
        }
    }

    public void BuyCar2()
    {
        if (gm.budget >= 200 && PlayerPrefs.GetInt("buttonText5", 0) != 1)
        {
            buttonText5.text = "BOUGHT";
            PlayerPrefs.SetInt("buttonText5", 1);
            gm.budget -= 200;
            hasUsedBut5 = "YES";
            PlayerPrefs.SetString("hasUsedBut5",hasUsedBut5);
        }
    }

    public void BuyCar3()
    {
        if (gm.budget >= 300 && PlayerPrefs.GetInt("buttonText6", 0) != 1)
        {
            buttonText6.text = "BOUGHT";
            PlayerPrefs.SetInt("buttonText6", 1);
            gm.budget -= 300;
            hasUsedBut6 = "YES";
            PlayerPrefs.SetString("hasUsedBut6",hasUsedBut6);
        }
    }

    public void UseButton1()
    {
        if (hasUsedBut1 == "YES")
        {
            ballSpriteRenderer.sprite = ball1;
            lastUsedBall = 1;
            PlayerPrefs.SetInt("lastUsedBall",lastUsedBall);
        }
            
    }
    public void UseButton2()
    {
        if (hasUsedBut2 == "YES")
        {
            ballSpriteRenderer.sprite = ball2;
            lastUsedBall = 2;
            PlayerPrefs.SetInt("lastUsedBall",lastUsedBall);
        }
            
    }
    public void UseButton3()
    {
        if (hasUsedBut3 == "YES")
        {
            ballSpriteRenderer.sprite = ball3;
            lastUsedBall = 3;
            PlayerPrefs.SetInt("lastUsedBall",lastUsedBall);
        }
            
    }

    public void UseButton4()
    {
        if (hasUsedBut4 == "YES")
        {
            playerSpriteRenderer.sprite = car1;
            lastUsedCar = 1;
            PlayerPrefs.SetInt("lastUsedCar",lastUsedCar);
        }
            
    }
    
    public void UseButton5()
    {
        if (hasUsedBut5 == "YES")
        {
            playerSpriteRenderer.sprite = car2;
            lastUsedCar = 2;
            PlayerPrefs.SetInt("lastUsedCar",lastUsedCar);
        }
            
    }

    public void UseButton6()
    {
        if (hasUsedBut6 == "YES")
        {
            playerSpriteRenderer.sprite = car3;
            lastUsedCar = 3;
            PlayerPrefs.SetInt("lastUsedCar",lastUsedCar);
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
