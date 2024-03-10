using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Diagnostics;

public class GameManager : MonoBehaviour
{
    #region General variables 
    
    public int enemyScore = 0;
    public int playerScore = 0;
    public float timer = 0;
    public int budget = 0;
    private bool isBestOfThree1,isBestOfThree2,isBestOfThree3,isBestOfThree4,isBestOfThree5,isBestOfThree6,
        isBestOfThree7,isBestOfThree8,isBestOfThree9,isBestOfThree10,isBestOfThree11,isBestOfThree12;
    [FormerlySerializedAs("LastLevel")] public int lastLevel=0;
    public List<GameObject> usedButtons;
    public bool isPassedLevel1,isPassedLevel2,isPassedLevel3,isPassedLevel4,isPassedLevel5,isPassedLevel6,
        isPassedLevel7,isPassedLevel8,isPassedLevel9,isPassedLevel10,isPassedLevel11,isPassedLevel12;

    public bool inGame;
    #endregion

    #region Texts

    [SerializeField] private Text enScoreText;
    [SerializeField] private Text plScoreText;
    [SerializeField] private Text timerText;
    [SerializeField] private Text countDownText;
    [SerializeField] private Text budgetText;
    [SerializeField] private Text levelText;
    
    #endregion

    #region "EnemySprites"

    [SerializeField] private Sprite cityEn;
    [SerializeField] private Sprite iceEn;
    [SerializeField] private Sprite fireEn;

    #endregion

    #region Gameobjects
    
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ball;
    // [SerializeField] private Camera cam;
    [SerializeField] private GameObject floor;
    [SerializeField] private GameObject square;
    [SerializeField] private Sprite freezeFloor;
    [SerializeField] private Sprite cityFloor;
    [SerializeField] private Sprite fireFloor;

    #endregion
    
    #region Panels

    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject ingamePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject skillTreePanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject freezeSkillTutorialPanel;
    [SerializeField] private GameObject powerShootTutorialPanel;
    [SerializeField] private GameObject levelTreeDisplayPanel;
    #endregion
    
    #region Script Instances

    [SerializeField] private EnemyScript es;
    [SerializeField] private PlayerMovements pm;
    [SerializeField] private BallMovements bm;
    [SerializeField] private SkillTreeManager stm;
    [SerializeField] private MarketScript ms;
    #endregion

    #region Buttons

    [SerializeField] private GameObject Button1,Button2,Button3,Button4,Button5,Button6,
        Button7,Button8,Button9,Button10,Button11,Button12;

    #endregion


    #region SoundController

    [SerializeField] private AudioClip inGameSound;
    [SerializeField] private AudioClip playSound;
    public AudioSource PlaySong;
    public AudioSource Supporter;

    #endregion
    #region Unity Methods

    private void FixedUpdate()
    {
        PlaySong = gameObject.GetComponent<AudioSource>();
    }

    private void Start()
    {
        SpriteSetter();
        budget = PlayerPrefs.GetInt("Budget");
        lastLevel = PlayerPrefs.GetInt("Level");
        StopTheGame();

        Button1.GetComponent<Button>().interactable = true;
        Button2.GetComponent<Button>().interactable = false;
        Button3.GetComponent<Button>().interactable = false;
        Button4.GetComponent<Button>().interactable = false;
        Button5.GetComponent<Button>().interactable = false;
        Button6.GetComponent<Button>().interactable = false;
        Button7.GetComponent<Button>().interactable = false;
        Button8.GetComponent<Button>().interactable = false;
        Button9.GetComponent<Button>().interactable = false;
        Button10.GetComponent<Button>().interactable = false;
        Button11.GetComponent<Button>().interactable = false;
        Button12.GetComponent<Button>().interactable = false;
        
        timer = 0;
        switch (lastLevel)
        {
            case 0:
                Button1.GetComponent<Button>().interactable = true;
                mainMenuPanel.SetActive(true);
                floor.GetComponent<SpriteRenderer>().sprite = cityFloor;
                square.GetComponent<SpriteRenderer>().color = Color.green;
                enemy.GetComponent<SpriteRenderer>().sprite = cityEn;
                enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;
            case 1:
                Button1.GetComponent<Button>().interactable = true;
                Button2.GetComponent<Button>().interactable = true;
                floor.GetComponent<SpriteRenderer>().sprite = cityFloor;
                square.GetComponent<SpriteRenderer>().color = Color.green;
                mainMenuPanel.SetActive(true);
                isBestOfThree1 = true;
                enemy.GetComponent<SpriteRenderer>().sprite = cityEn;
                enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;
            case 2:
                Button1.GetComponent<Button>().interactable = true;
                Button2.GetComponent<Button>().interactable = true;
                Button3.GetComponent<Button>().interactable = true;
                floor.GetComponent<SpriteRenderer>().sprite = cityFloor;
                square.GetComponent<SpriteRenderer>().color = Color.green;
                mainMenuPanel.SetActive(true);
                isBestOfThree2 = true;
                isPassedLevel1 = true;
                isPassedLevel2 = true;
                enemy.GetComponent<SpriteRenderer>().sprite = cityEn;
                enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;
            case 3:
                Button1.GetComponent<Button>().interactable = true;
                Button2.GetComponent<Button>().interactable = true;
                Button3.GetComponent<Button>().interactable = true;
                Button4.GetComponent<Button>().interactable = true;
                mainMenuPanel.SetActive(true);
                isBestOfThree3 = true;
                floor.GetComponent<SpriteRenderer>().sprite = freezeFloor;
                square.GetComponent<SpriteRenderer>().color = Color.blue;
                isPassedLevel1 = true;
                isPassedLevel2 = true;
                isPassedLevel3 = true;
                enemy.GetComponent<SpriteRenderer>().sprite = iceEn;
                enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;
            case 4:
                Button1.GetComponent<Button>().interactable = true;
                Button2.GetComponent<Button>().interactable = true;
                Button3.GetComponent<Button>().interactable = true;
                Button4.GetComponent<Button>().interactable = true;
                Button5.GetComponent<Button>().interactable = true;
                floor.GetComponent<SpriteRenderer>().sprite = freezeFloor;
                square.GetComponent<SpriteRenderer>().color = Color.blue;
                mainMenuPanel.SetActive(true);
                stm.isFreezeSkillUnlocked = true;
                isBestOfThree4 = true;
                isPassedLevel1 = true;
                isPassedLevel2 = true;
                isPassedLevel3 = true;
                isPassedLevel4 = true;
                enemy.GetComponent<SpriteRenderer>().sprite = iceEn;
                enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;
            case 5:
                Button1.GetComponent<Button>().interactable = true;
                Button2.GetComponent<Button>().interactable = true;
                Button3.GetComponent<Button>().interactable = true;
                Button4.GetComponent<Button>().interactable = true;
                Button5.GetComponent<Button>().interactable = true;
                Button6.GetComponent<Button>().interactable = true;
                floor.GetComponent<SpriteRenderer>().sprite = freezeFloor;
                square.GetComponent<SpriteRenderer>().color = Color.blue;
                mainMenuPanel.SetActive(true);
                stm.isFreezeSkillUnlocked = true;
                isBestOfThree5= true;
                isPassedLevel1 = true;
                isPassedLevel2 = true;
                isPassedLevel3 = true;
                isPassedLevel4 = true;
                isPassedLevel4 = true;
                isPassedLevel5 = true;
                enemy.GetComponent<SpriteRenderer>().sprite = iceEn;
                enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;
            case 6:
                Button1.GetComponent<Button>().interactable = true;
                Button2.GetComponent<Button>().interactable = true;
                Button3.GetComponent<Button>().interactable = true;
                Button4.GetComponent<Button>().interactable = true;
                Button5.GetComponent<Button>().interactable = true;
                Button6.GetComponent<Button>().interactable = true;
                Button7.GetComponent<Button>().interactable = true;
                floor.GetComponent<SpriteRenderer>().sprite = freezeFloor;
                square.GetComponent<SpriteRenderer>().color = Color.blue;
                mainMenuPanel.SetActive(true);
                stm.isFreezeSkillUnlocked = true;
                isBestOfThree6 = true;
                isPassedLevel1 = true;
                isPassedLevel2 = true;
                isPassedLevel3 = true;
                isPassedLevel4 = true;
                isPassedLevel4 = true;
                isPassedLevel5 = true;
                isPassedLevel6 = true;
                enemy.GetComponent<SpriteRenderer>().sprite = iceEn;
                enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;
            case 7:
                Button1.GetComponent<Button>().interactable = true;
                Button2.GetComponent<Button>().interactable = true;
                Button3.GetComponent<Button>().interactable = true;
                Button4.GetComponent<Button>().interactable = true;
                Button5.GetComponent<Button>().interactable = true;
                Button6.GetComponent<Button>().interactable = true;
                Button7.GetComponent<Button>().interactable = true;
                Button8.GetComponent<Button>().interactable = true;
                floor.GetComponent<SpriteRenderer>().sprite = freezeFloor;
                square.GetComponent<SpriteRenderer>().color = Color.blue;
                mainMenuPanel.SetActive(true);
                stm.isFreezeSkillUnlocked = true;
                isBestOfThree7 = true;
                isPassedLevel1 = true;
                isPassedLevel2 = true;
                isPassedLevel3 = true;
                isPassedLevel4 = true;
                isPassedLevel4 = true;
                isPassedLevel5 = true;
                isPassedLevel6 = true;
                isPassedLevel7 = true;
                enemy.GetComponent<SpriteRenderer>().sprite = iceEn;
                enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;
            case 8:
                Button1.GetComponent<Button>().interactable = true;
                Button2.GetComponent<Button>().interactable = true;
                Button3.GetComponent<Button>().interactable = true;
                Button4.GetComponent<Button>().interactable = true;
                Button5.GetComponent<Button>().interactable = true;
                Button6.GetComponent<Button>().interactable = true;
                Button7.GetComponent<Button>().interactable = true;
                Button8.GetComponent<Button>().interactable = true;
                Button9.GetComponent<Button>().interactable = true;
                floor.GetComponent<SpriteRenderer>().sprite = freezeFloor;
                square.GetComponent<SpriteRenderer>().color = Color.blue;
                stm.isFreezeSkillUnlocked = true;
                stm.isPowerUpSkillUnlocked = true;
                mainMenuPanel.SetActive(true);
                isBestOfThree8 = true;
                isPassedLevel1 = true;
                isPassedLevel2 = true;
                isPassedLevel3 = true;
                isPassedLevel4 = true;
                isPassedLevel4 = true;
                isPassedLevel5 = true;
                isPassedLevel6 = true;
                isPassedLevel7 = true;
                isPassedLevel8 = true;
                enemy.GetComponent<SpriteRenderer>().sprite = iceEn;
                enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;
            case 9:
                Button1.GetComponent<Button>().interactable = true;
                Button2.GetComponent<Button>().interactable = true;
                Button3.GetComponent<Button>().interactable = true;
                Button4.GetComponent<Button>().interactable = true;
                Button5.GetComponent<Button>().interactable = true;
                Button6.GetComponent<Button>().interactable = true;
                Button7.GetComponent<Button>().interactable = true;
                Button8.GetComponent<Button>().interactable = true;
                Button9.GetComponent<Button>().interactable = true;
                Button10.GetComponent<Button>().interactable = true;
                floor.GetComponent<SpriteRenderer>().sprite = fireFloor;
                square.GetComponent<SpriteRenderer>().color = Color.red;
                mainMenuPanel.SetActive(true);
                stm.isFreezeSkillUnlocked = true;
                stm.isPowerUpSkillUnlocked = true;
                isBestOfThree9 = true;
                isPassedLevel1 = true;
                isPassedLevel2 = true;
                isPassedLevel3 = true;
                isPassedLevel4 = true;
                isPassedLevel4 = true;
                isPassedLevel5 = true;
                isPassedLevel6 = true;
                isPassedLevel7 = true;
                isPassedLevel8 = true;
                isPassedLevel9 = true;
                enemy.GetComponent<SpriteRenderer>().sprite = fireEn;
                enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;
            case 10:
                Button1.GetComponent<Button>().interactable = true;
                Button2.GetComponent<Button>().interactable = true;
                Button3.GetComponent<Button>().interactable = true;
                Button4.GetComponent<Button>().interactable = true;
                Button5.GetComponent<Button>().interactable = true;
                Button6.GetComponent<Button>().interactable = true;
                Button7.GetComponent<Button>().interactable = true;
                Button8.GetComponent<Button>().interactable = true;
                Button9.GetComponent<Button>().interactable = true;
                Button10.GetComponent<Button>().interactable = true;
                Button11.GetComponent<Button>().interactable = true;
                floor.GetComponent<SpriteRenderer>().sprite = fireFloor;
                square.GetComponent<SpriteRenderer>().color = Color.red;
                mainMenuPanel.SetActive(true);
                stm.isFreezeSkillUnlocked = true;
                stm.isPowerUpSkillUnlocked = true;
                isBestOfThree10 = true;
                isPassedLevel1 = true;
                isPassedLevel2 = true;
                isPassedLevel3 = true;
                isPassedLevel4 = true;
                isPassedLevel4 = true;
                isPassedLevel5 = true;
                isPassedLevel6 = true;
                isPassedLevel7 = true;
                isPassedLevel8 = true;
                isPassedLevel9 = true;
                isPassedLevel10 = true;
                enemy.GetComponent<SpriteRenderer>().sprite = fireEn;
                enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;
            case 11:
                Button1.GetComponent<Button>().interactable = true;
                Button2.GetComponent<Button>().interactable = true;
                Button3.GetComponent<Button>().interactable = true;
                Button4.GetComponent<Button>().interactable = true;
                Button5.GetComponent<Button>().interactable = true;
                Button6.GetComponent<Button>().interactable = true;
                Button7.GetComponent<Button>().interactable = true;
                Button8.GetComponent<Button>().interactable = true;
                Button9.GetComponent<Button>().interactable = true;
                Button10.GetComponent<Button>().interactable = true;
                Button11.GetComponent<Button>().interactable = true;
                Button12.GetComponent<Button>().interactable = true;
                floor.GetComponent<SpriteRenderer>().sprite = fireFloor;
                square.GetComponent<SpriteRenderer>().color = Color.red;
                mainMenuPanel.SetActive(true);
                stm.isFreezeSkillUnlocked = true;
                stm.isPowerUpSkillUnlocked = true;
                isBestOfThree11 = true;
                isPassedLevel1 = true;
                isPassedLevel2 = true;
                isPassedLevel3 = true;
                isPassedLevel4 = true;
                isPassedLevel4 = true;
                isPassedLevel5 = true;
                isPassedLevel6 = true;
                isPassedLevel7 = true;
                isPassedLevel8 = true;
                isPassedLevel9 = true;
                isPassedLevel10 = true;
                isPassedLevel11 = true;
                enemy.GetComponent<SpriteRenderer>().sprite = fireEn;
                enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;
            case 12:
                mainMenuPanel.SetActive(true);
                isBestOfThree12 = true;
                floor.GetComponent<SpriteRenderer>().sprite = fireFloor;
                square.GetComponent<SpriteRenderer>().color = Color.red;
                stm.isFreezeSkillUnlocked = true;
                stm.isPowerUpSkillUnlocked = true;
                isPassedLevel1 = true;
                isPassedLevel2 = true;
                isPassedLevel3 = true;
                isPassedLevel4 = true;
                isPassedLevel4 = true;
                isPassedLevel5 = true;
                isPassedLevel6 = true;
                isPassedLevel7 = true;
                isPassedLevel8 = true;
                isPassedLevel9 = true;
                isPassedLevel10 = true;
                isPassedLevel11 = true;
                isPassedLevel12 = true;
                enemy.GetComponent<SpriteRenderer>().sprite = fireEn;
                enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;
            default:
                OnLevel1Click();
                break;
        }
    }

    public void SpriteSetter()
    {
        if (PlayerPrefs.GetInt("lastUsedBall") == 1)
        {
            ms.ballSpriteRenderer.sprite = ms.ball1;
        }
        if (PlayerPrefs.GetInt("lastUsedBall") == 2)
        {
            ms. ballSpriteRenderer.sprite = ms.ball2;
        }
        if (PlayerPrefs.GetInt("lastUsedBall") == 3)
        {
            ms.ballSpriteRenderer.sprite = ms.ball3;    
        }
        if (PlayerPrefs.GetInt("lastUsedCar") == 1)
        {
                   ms. playerSpriteRenderer.sprite = ms.car1; 
        }
        if (PlayerPrefs.GetInt("lastUsedCar") == 2)
        {
                 ms. playerSpriteRenderer.sprite = ms.car2;   
        }
        if (PlayerPrefs.GetInt("lastUsedCar") == 3)
        {
                    ms.playerSpriteRenderer.sprite = ms.car3;
        }
    }

    void Update()
    {

        budgetText.text = PlayerPrefs.GetInt("Budget").ToString();
        levelText.text = PlayerPrefs.GetInt("Level").ToString();

        enScoreText.text = enemyScore.ToString();
        plScoreText.text = playerScore.ToString();
        timerText.text = Mathf.Floor(timer).ToString();
        

       
        if (isBestOfThree1)
        {
            timer += Time.deltaTime;
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree2 = true;
                freeze.SetActive(false);
                powerShot.SetActive(false);
                if (!isPassedLevel1)
                {
                    lastLevel++;
                    isPassedLevel1 = true;
                }
               
                PlayerPrefs.SetInt("Level", lastLevel);
                isBestOfThree1 = isBestOfThree2 = isBestOfThree3 = isBestOfThree4 = isBestOfThree5 = isBestOfThree6 = 
                    isBestOfThree7 = isBestOfThree8 = isBestOfThree9 = isBestOfThree10 = isBestOfThree11 = isBestOfThree12 = false;
                Button2.GetComponent<Button>().interactable = true;
                timer = 0;
            }
            if (timer >= 60f && inGame)  
            {
                losePanel.SetActive(true);
                StopTheGame();
            }
            if (enemyScore == 3)
            {
                StopTheGame();
                losePanel.SetActive(true);
                freeze.SetActive(false);
                powerShot.SetActive(false);
                timer = 0;
            }
        }
        else if (isBestOfThree2)
        {
            timer += Time.deltaTime;
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree3 = true;
                freeze.SetActive(false);
                powerShot.SetActive(false);
                if (!isPassedLevel2)
                {
                    lastLevel++;
                    isPassedLevel2 = true;
                }
                PlayerPrefs.SetInt("Level", lastLevel);
                bm.goalPanel.SetActive(false);
                bm.GoalEffectInstance.SetActive(false);
                isBestOfThree1 = isBestOfThree2 = isBestOfThree3 = isBestOfThree4 = isBestOfThree5 = isBestOfThree6 = 
                    isBestOfThree7 = isBestOfThree8 = isBestOfThree9 = isBestOfThree10 = isBestOfThree11 = isBestOfThree12 = false;
                timer = 0;
                Button3.GetComponent<Button>().interactable = true;
            }
            if (timer >= 60f)  
            {
                losePanel.SetActive(true);
                StopTheGame();
            }
            if (enemyScore == 3)
            {
                StopTheGame();
                losePanel.SetActive(true);
                isBestOfThree3 = false;
                freeze.SetActive(false);
                powerShot.SetActive(false);
                timer = 0;
            }
        }else if (isBestOfThree3)
        {
            timer += Time.deltaTime;
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree4 = true;
                freeze.SetActive(false);
                powerShot.SetActive(false);
                floor.GetComponent<SpriteRenderer>().sprite = freezeFloor;
                square.GetComponent<SpriteRenderer>().color = Color.blue;
                if (!isPassedLevel3)
                {
                    freezeSkillTutorialPanel.SetActive(true);
                    lastLevel++;
                    isPassedLevel3 = true;
                }
                bm.goalPanel.SetActive(false);
                bm.GoalEffectInstance.SetActive(false);
                PlayerPrefs.SetInt("Level", lastLevel); 
                isBestOfThree1 = isBestOfThree2 = isBestOfThree3 = isBestOfThree4 = isBestOfThree5 = isBestOfThree6 = 
                    isBestOfThree7 = isBestOfThree8 = isBestOfThree9 = isBestOfThree10 = isBestOfThree11 = isBestOfThree12 = false;
                Button4.GetComponent<Button>().interactable = true;
                timer = 0;
            }
            if (timer >= 60f)  
            {
                losePanel.SetActive(true);
                StopTheGame();
            }
            if (enemyScore == 3)
            {
                StopTheGame();
                losePanel.SetActive(true);
                freeze.SetActive(false);
                powerShot.SetActive(false);
                timer = 0;
            }
        }else if (isBestOfThree4)
        {
            timer += Time.deltaTime;
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree5 = true;
                freeze.SetActive(false);
                powerShot.SetActive(false);
                if (!isPassedLevel4)
                {
                    lastLevel++;
                    isPassedLevel4 = true;
                }
                PlayerPrefs.SetInt("Level", lastLevel);
                bm.goalPanel.SetActive(false);
                bm.GoalEffectInstance.SetActive(false);
                isBestOfThree1 = isBestOfThree2 = isBestOfThree3 = isBestOfThree4 = isBestOfThree5 = isBestOfThree6 = isBestOfThree7 = 
                    isBestOfThree8 = isBestOfThree9 = isBestOfThree10 = isBestOfThree11 = isBestOfThree12 = false;
                Button5.GetComponent<Button>().interactable = true;
                timer = 0;
            }
            if (timer >= 60f)  
            {
                losePanel.SetActive(true);
                StopTheGame();
            }
            if (enemyScore == 3)
            {
                StopTheGame();
                losePanel.SetActive(true);
                freeze.SetActive(false);
                powerShot.SetActive(false);
                timer = 0;
            }
        }else if (isBestOfThree5)
        {
            timer += Time.deltaTime;
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree6 = true;
                freeze.SetActive(false);
                powerShot.SetActive(false);
                if (!isPassedLevel5)
                {
                    lastLevel++;
                    isPassedLevel5 = true;
                }
                PlayerPrefs.SetInt("Level", lastLevel); 
                bm.goalPanel.SetActive(false);
                bm.GoalEffectInstance.SetActive(false);
                isBestOfThree1 = isBestOfThree2 = isBestOfThree3 = isBestOfThree4 = isBestOfThree5 = isBestOfThree6 = 
                    isBestOfThree7 = isBestOfThree8 = isBestOfThree9 = isBestOfThree10 = isBestOfThree11 = isBestOfThree12 = false;
                Button6.GetComponent<Button>().interactable = true;
                timer = 0;
            }
            if (timer >= 60f)  
            {
                losePanel.SetActive(true);
                StopTheGame();
            }
            if (enemyScore == 3)
            {
                StopTheGame();
                losePanel.SetActive(true);
                freeze.SetActive(false);
                powerShot.SetActive(false);
                timer = 0;
            }
        }else if (isBestOfThree6)
        {
            timer += Time.deltaTime;
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree7 = true;
                freeze.SetActive(false);
                powerShot.SetActive(false);
                if (!isPassedLevel6)
                {
                    lastLevel++;
                    isPassedLevel6 = true;
                }
                PlayerPrefs.SetInt("Level", lastLevel); 
                bm.goalPanel.SetActive(false);
                bm.GoalEffectInstance.SetActive(false);
                isBestOfThree1 = isBestOfThree2 = isBestOfThree3 = isBestOfThree4 = isBestOfThree5 = isBestOfThree6 = 
                    isBestOfThree7 = isBestOfThree8 = isBestOfThree9 = isBestOfThree10 = isBestOfThree11 = isBestOfThree12 = false;
                Button7.GetComponent<Button>().interactable = true;
                timer = 0;
            }
            if (timer >= 60f)  
            {
                losePanel.SetActive(true);
                StopTheGame();
            }
            if (enemyScore == 3)
            {
                StopTheGame();
                losePanel.SetActive(true);
                freeze.SetActive(false);
                powerShot.SetActive(false);
                timer = 0;
            }
        }else if (isBestOfThree7)
        {
            timer += Time.deltaTime;
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree8 = true;
                freeze.SetActive(false);
                powerShot.SetActive(false);
                if (!isPassedLevel7)
                {
                    lastLevel++;
                    isPassedLevel7 = true;
                }
                PlayerPrefs.SetInt("Level", lastLevel);
                bm.goalPanel.SetActive(false);
                bm.GoalEffectInstance.SetActive(false);
                isBestOfThree1 = isBestOfThree2 = isBestOfThree3 = isBestOfThree4 = isBestOfThree5 = isBestOfThree6 = 
                    isBestOfThree7 = isBestOfThree8 = isBestOfThree9 = isBestOfThree10 = isBestOfThree11 = isBestOfThree12 = false;
                Button8.GetComponent<Button>().interactable = true;
                timer = 0;
            }
            if (timer >= 60f)  
            {
                losePanel.SetActive(true);
                StopTheGame();
            }
            if (enemyScore == 3)
            {
                StopTheGame();
                losePanel.SetActive(true);
                freeze.SetActive(false);
                powerShot.SetActive(false);
                timer = 0;
            }
        }else if (isBestOfThree8)
        {
            timer += Time.deltaTime;
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree9 = true;
                freeze.SetActive(false);
                powerShot.SetActive(false);
                if (!isPassedLevel8)
                {
                    powerShootTutorialPanel.SetActive(true);
                    lastLevel++;
                    isPassedLevel8 = true;
                }
                
                PlayerPrefs.SetInt("Level", lastLevel); 
                bm.goalPanel.SetActive(false);
                bm.GoalEffectInstance.SetActive(false);
                isBestOfThree1 = isBestOfThree2 = isBestOfThree3 = isBestOfThree4 = isBestOfThree5 = isBestOfThree6 = 
                    isBestOfThree7 = isBestOfThree8 = isBestOfThree9 = isBestOfThree10 = isBestOfThree11 = isBestOfThree12 = false;
                Button9.GetComponent<Button>().interactable = true;
                timer = 0;
            }
            if (timer >= 60f)  
            {
                losePanel.SetActive(true);
                StopTheGame();
            }
            if (enemyScore == 3)
            {
                StopTheGame();
                losePanel.SetActive(true);
                freeze.SetActive(false);
                powerShot.SetActive(false);
                timer = 0;
            }
        }else if (isBestOfThree9)
        {
            timer += Time.deltaTime;
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree10 = true;
                freeze.SetActive(false);
                powerShot.SetActive(false);
                if (!isPassedLevel9)
                {
                    lastLevel++;
                    isPassedLevel9 = true;
                }
                PlayerPrefs.SetInt("Level", lastLevel);
                bm.goalPanel.SetActive(false);
                bm.GoalEffectInstance.SetActive(false);
                isBestOfThree1 = isBestOfThree2 = isBestOfThree3 = isBestOfThree4 = isBestOfThree5 = isBestOfThree6 = 
                    isBestOfThree7 = isBestOfThree8 = isBestOfThree9 = isBestOfThree10 = isBestOfThree11 = isBestOfThree12 = false;
                Button10.GetComponent<Button>().interactable = true;
                timer = 0;
            }
            if (timer >= 60f)  
            {
                losePanel.SetActive(true);
                StopTheGame();
            }
            if (enemyScore == 3)
            {
                StopTheGame();
                losePanel.SetActive(true);
                freeze.SetActive(false);
                powerShot.SetActive(false);
                timer = 0;
            }
        }else if (isBestOfThree10)
        {
            timer += Time.deltaTime;
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree11 = true;
                freeze.SetActive(false);
                powerShot.SetActive(false);
                if (!isPassedLevel10)
                {
                    lastLevel++;
                    isPassedLevel10 = true;
                }
                PlayerPrefs.SetInt("Level", lastLevel); 
                bm.goalPanel.SetActive(false);
                bm.GoalEffectInstance.SetActive(false);
                isBestOfThree1 = isBestOfThree2 = isBestOfThree3 = isBestOfThree4 = isBestOfThree5 = isBestOfThree6 = 
                    isBestOfThree7 = isBestOfThree8 = isBestOfThree9 = isBestOfThree10 = isBestOfThree11 = isBestOfThree12 = false;
                Button11.GetComponent<Button>().interactable = true;
                timer = 0;
            }
            if (timer >= 60f)  
            {
                losePanel.SetActive(true);
                StopTheGame();
            }
            if (enemyScore == 3)
            {
                StopTheGame();
                losePanel.SetActive(true);
                freeze.SetActive(false);
                powerShot.SetActive(false);
                timer = 0;
            }
        }else if (isBestOfThree11)
        {
            timer += Time.deltaTime;
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree12 = true;
                freeze.SetActive(false);
                powerShot.SetActive(false);
                if (!isPassedLevel11)
                {
                    lastLevel++;
                    isPassedLevel11 = true;
                }
                PlayerPrefs.SetInt("Level", lastLevel);
                bm.goalPanel.SetActive(false);
                bm.GoalEffectInstance.SetActive(false);
                isBestOfThree1 = isBestOfThree2 = isBestOfThree3 = isBestOfThree4 = isBestOfThree5 = isBestOfThree6 = 
                    isBestOfThree7 = isBestOfThree8 = isBestOfThree9 = isBestOfThree10 = isBestOfThree11 = isBestOfThree12 = false;
                Button12.GetComponent<Button>().interactable = true;
                timer = 0;
            }
            if (timer >= 60f)  
            {
                losePanel.SetActive(true);
                StopTheGame();
            }
            if (enemyScore == 3)
            {
                StopTheGame();
                losePanel.SetActive(true);
                freeze.SetActive(false);
                powerShot.SetActive(false);
                timer = 0;
            }
        }else if (isBestOfThree12)
        {
            timer += Time.deltaTime;
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree1 = true;
                freeze.SetActive(false);
                powerShot.SetActive(false);
                if (!isPassedLevel12)
                {
                    lastLevel++;
                    isPassedLevel12 = true;
                }
                PlayerPrefs.SetInt("Level", lastLevel); 
                bm.goalPanel.SetActive(false);
                bm.GoalEffectInstance.SetActive(false);
                isBestOfThree1 = isBestOfThree2 = isBestOfThree3 = isBestOfThree4 = isBestOfThree5 = isBestOfThree6 = 
                    isBestOfThree7 = isBestOfThree8 = isBestOfThree9 = isBestOfThree10 = isBestOfThree11 = isBestOfThree12 = false;
                timer = 0;
            }
            if (timer >= 60f)  
            {
                losePanel.SetActive(true);
                StopTheGame();
            }
            if (enemyScore == 3)
            {
                StopTheGame();
                losePanel.SetActive(true);
                freeze.SetActive(false);
                powerShot.SetActive(false);
                timer = 0;
            }
        }
        if (!isBestOfThree1 && !isBestOfThree2 && !isBestOfThree3 && !isBestOfThree4 && !isBestOfThree5 && !isBestOfThree6 &&
            !isBestOfThree7 && !isBestOfThree8 && !isBestOfThree9 && !isBestOfThree10 && !isBestOfThree11 && !isBestOfThree12)
        {
            timer = 0;
        }
        
        #region PlayerPrefs
        PlayerPrefs.SetInt("Budget", budget);
        PlayerPrefs.SetInt("Level", lastLevel);
        #endregion
    }

    #endregion

    #region Skills variables
    [SerializeField] private GameObject freeze;
    [SerializeField] private GameObject powerShot;
    [SerializeField] private Button  FrezeerButton;
    [SerializeField] private Button PowerShotbutton;
    #endregion

    #region Level Functions

    private void OnLevel1Click()
    {
        levelTreeDisplayPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        isBestOfThree1 = true;
        // EnmeySkills.EnemyHaveFrezeer = true;
        // EnmeySkills.enemyHavePowerShot = true;
        floor.GetComponent<SpriteRenderer>().sprite = cityFloor;
        square.GetComponent<SpriteRenderer>().color = Color.green;
        // FrezeerSkill();
        // PowerShootSkill();
        bm.goalPanel.SetActive(false);
        bm.GoalEffectInstance.SetActive(false);
        enemy.GetComponent<SpriteRenderer>().sprite = cityEn;
        enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
    private void OnLevel2Click()
    {
        levelTreeDisplayPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        isBestOfThree2 = true;
        floor.GetComponent<SpriteRenderer>().sprite = cityFloor;
        square.GetComponent<SpriteRenderer>().color = Color.green;
        // EnmeySkills.EnemyHaveFrezeer = false;
        // EnmeySkills.enemyHavePowerShot = false;
        bm.goalPanel.SetActive(false);
        bm.GoalEffectInstance.SetActive(false);
        enemy.GetComponent<SpriteRenderer>().sprite = cityEn;
        enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    private void OnLevel3Click()
    {
        levelTreeDisplayPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        isBestOfThree3 = true;
        floor.GetComponent<SpriteRenderer>().sprite = cityFloor;
        square.GetComponent<SpriteRenderer>().color = Color.green;
        // EnmeySkills.EnemyHaveFrezeer = false;
        // EnmeySkills.enemyHavePowerShot = false;
        bm.goalPanel.SetActive(false);
        bm.GoalEffectInstance.SetActive(false);
        enemy.GetComponent<SpriteRenderer>().sprite = cityEn;
        enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
    private void OnLevel4Click()
    {
        levelTreeDisplayPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        freeze.SetActive(true);
        FrezeerSkill();
        isBestOfThree4 = true;
        floor.GetComponent<SpriteRenderer>().sprite = freezeFloor;
        square.GetComponent<SpriteRenderer>().color = Color.blue;
        stm.isFreezeSkillUnlocked = true;
        EnmeySkills.EnemyHaveFrezeer = true;
        // EnmeySkills.enemyHavePowerShot = false;
        bm.goalPanel.SetActive(false);
        bm.GoalEffectInstance.SetActive(false);
        enemy.GetComponent<SpriteRenderer>().sprite = iceEn;
        enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
    private void OnLevel5Click()
    {
        levelTreeDisplayPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        FrezeerSkill();
        floor.GetComponent<SpriteRenderer>().sprite = freezeFloor;
        square.GetComponent<SpriteRenderer>().color = Color.blue;
        EnmeySkills.EnemyHaveFrezeer = true;
        // EnmeySkills.enemyHavePowerShot = false;
        bm.goalPanel.SetActive(false);
        bm.GoalEffectInstance.SetActive(false);
        enemy.GetComponent<SpriteRenderer>().sprite = iceEn;
        enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        isBestOfThree5 = true;
    }
    private void OnLevel6Click()
    {
        levelTreeDisplayPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        FrezeerSkill();
        floor.GetComponent<SpriteRenderer>().sprite = freezeFloor;
        square.GetComponent<SpriteRenderer>().color = Color.blue;
        EnmeySkills.EnemyHaveFrezeer = true;
        // EnmeySkills.enemyHavePowerShot = false;
        bm.goalPanel.SetActive(false);
        bm.GoalEffectInstance.SetActive(false);
        isBestOfThree6 = true;
        enemy.GetComponent<SpriteRenderer>().sprite = iceEn;
        enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    } 
    private void OnLevel7Click()
    {
        levelTreeDisplayPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        FrezeerSkill();
        floor.GetComponent<SpriteRenderer>().sprite = freezeFloor;
        square.GetComponent<SpriteRenderer>().color = Color.blue;
        EnmeySkills.EnemyHaveFrezeer = true;
        // EnmeySkills.enemyHavePowerShot = true;
        bm.goalPanel.SetActive(false);
        bm.GoalEffectInstance.SetActive(false);
        isBestOfThree7 = true;
        enemy.GetComponent<SpriteRenderer>().sprite = iceEn;
        enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
    private void OnLevel8Click()
    {
        levelTreeDisplayPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        FrezeerSkill();
        floor.GetComponent<SpriteRenderer>().sprite = freezeFloor;
        square.GetComponent<SpriteRenderer>().color = Color.blue;
        EnmeySkills.EnemyHaveFrezeer = true;
        EnmeySkills.enemyHavePowerShot = true;
        bm.goalPanel.SetActive(false);
        bm.GoalEffectInstance.SetActive(false);
        powerShot.SetActive(true);
        isBestOfThree8 = true;
        stm.isPowerUpSkillUnlocked = true;
        enemy.GetComponent<SpriteRenderer>().sprite = iceEn;
        enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        
    } 
    private void OnLevel9Click()
    {
        levelTreeDisplayPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        FrezeerSkill();
        PowerShootSkill();
        floor.GetComponent<SpriteRenderer>().sprite = fireFloor;
        square.GetComponent<SpriteRenderer>().color = Color.red;
        EnmeySkills.EnemyHaveFrezeer = true;
        EnmeySkills.enemyHavePowerShot = true;
        bm.goalPanel.SetActive(false);
        bm.GoalEffectInstance.SetActive(false);
        isBestOfThree9 = true;
        enemy.GetComponent<SpriteRenderer>().sprite = fireEn;
        enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    } 
    private void OnLevel10Click()
    {
        levelTreeDisplayPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        isBestOfThree10 = true;
        floor.GetComponent<SpriteRenderer>().sprite = fireFloor;
        square.GetComponent<SpriteRenderer>().color = Color.red;
        EnmeySkills.EnemyHaveFrezeer = true;
        EnmeySkills.enemyHavePowerShot = true;
        bm.goalPanel.SetActive(false);
        bm.GoalEffectInstance.SetActive(false);
        FrezeerSkill();
        PowerShootSkill();
        enemy.GetComponent<SpriteRenderer>().sprite = fireEn;
        enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    } private void OnLevel11Click()
    {
        levelTreeDisplayPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        FrezeerSkill();
        PowerShootSkill();
        floor.GetComponent<SpriteRenderer>().sprite = fireFloor;
        square.GetComponent<SpriteRenderer>().color = Color.red;
        EnmeySkills.EnemyHaveFrezeer = true;
        EnmeySkills.enemyHavePowerShot = true;
        bm.goalPanel.SetActive(false);
        bm.GoalEffectInstance.SetActive(false);
        isBestOfThree11 = true;
        enemy.GetComponent<SpriteRenderer>().sprite = fireEn;
        enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    } private void OnLevel12Click()
    {
        levelTreeDisplayPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        floor.GetComponent<SpriteRenderer>().sprite = fireFloor;
        square.GetComponent<SpriteRenderer>().color = Color.red;
        EnmeySkills.EnemyHaveFrezeer = true;
        EnmeySkills.enemyHavePowerShot = true;
        bm.goalPanel.SetActive(false);
        bm.GoalEffectInstance.SetActive(false);
        FrezeerSkill();
        PowerShootSkill();
        isBestOfThree12 = true;
        enemy.GetComponent<SpriteRenderer>().sprite = fireEn;
        enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
    #endregion


    private void PlaySoundPlayer()
    {
        PlaySong.clip = playSound;
        PlaySong.loop = true;
        PlaySong.Play();
        Supporter.Play();
    }
    
    public void DisplayLevelTree()
    {
        ingamePanel.SetActive(false);
       levelTreeDisplayPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    #region button levelContollers
    public void ButtonLevel1Controler()
    {
        OnLevel1Click();
        PlaySoundPlayer();
    }
    public void ButtonLevel2Controler()
    {
        OnLevel2Click();
        PlaySoundPlayer();
    }

    public void ButtonLevel3Controler()
    {
        OnLevel3Click();
        PlaySoundPlayer();
    }
    public void ButtonLevel4Controler()
    {
        OnLevel4Click();
        PlaySoundPlayer();
    }
    public void ButtonLevel5Controler()
    {
        OnLevel5Click();
        PlaySoundPlayer();
    }
    public void ButtonLevel6Controler()
    {
        OnLevel6Click();
        PlaySoundPlayer();
    }
    public void ButtonLevel7Controler()
    {
        OnLevel7Click();
        PlaySoundPlayer();
    }
    public void ButtonLevel8Controler()
    {
        OnLevel8Click();
        PlaySoundPlayer();
    }
    public void ButtonLevel9Controler()
    {
        OnLevel9Click();
        PlaySoundPlayer();
    }
    public void ButtonLevel10Controler()
    {
        OnLevel10Click();
        PlaySoundPlayer();
    }
    public void ButtonLevel11Controler()
    {
        OnLevel11Click();
        PlaySoundPlayer();
    }
    public void ButtonLevel12Controler()
    {
        OnLevel2Click();
        PlaySoundPlayer();
    }
    #endregion


    
    private void StopTheGame()
    {
        mainMenuPanel.SetActive(true);
        enemyScore = 0;
        playerScore = 0;
        enemy.SetActive(false);
        player.SetActive(false);
        ball.SetActive(false);
        timer = 0;
        enemy.GetComponent<Rigidbody2D>().velocity= Vector2.zero;
        player.GetComponent<Rigidbody2D>().velocity=Vector2.zero;
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        PlaySong.clip = inGameSound;
        PlaySong.loop = true;
        PlaySong.Play();
        Supporter.Stop();
        inGame = false;
    }

    private void StartTheGameplay()
    {
        enemyScore = 0;
        playerScore = 0;
        timer = 0;
        enemy.transform.position = es.enemyStartPoint.position;
        player.transform.position = pm.playerStartPoint.position;
        ball.transform.position = bm.ballStartPoint.position;
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ball.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        ingamePanel.SetActive(true);
        enemy.SetActive(true);
        player.SetActive(true);
        ball.SetActive(true);
        EnmeySkills.canPowerShot = false;
        inGame = true;
    }

    #region CounterRegion

    private void StartCountdown()
    {
        StartCoroutine(CountdownCoroutine());
        
    }
    private System.Collections.IEnumerator CountdownCoroutine()
    {

        for (int i = 3; i > 0; i--)
        {
            countDownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        countDownText.text = "Go!";
        yield return new WaitForSeconds(1f);
        StartTheGameplay();
        countDownText.text = "";
    }

    #endregion

    #region Skills

    private void FrezeerSkill()
    {
        freeze.SetActive(true);
        FrezeerButton.interactable = true;
        PlayerSkills.frezeerUsed = false;
    }
    private void PowerShootSkill()
    {
        powerShot.SetActive(true);
        PowerShotbutton.interactable = true;
    }

    #endregion

    #region ButtonFunctions

    public void BackToMenuButtonForWinner()
    {
        winPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    public void BackToMenuButtonForLoser()
    {
        losePanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void OpenSkillTree()
    {
        skillTreePanel.SetActive(true);
    }

    public void BackFromSkillTree()
    {
        skillTreePanel.SetActive(false);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }
    
    public void BackFromSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void BackToMenuButtonForFreezeTutorial()
    {
        freezeSkillTutorialPanel.SetActive(false);
    }

    public void BackToMenuButtonForPowerShootTutorial()
    {
        powerShootTutorialPanel.SetActive(false);
    }

    #endregion
}