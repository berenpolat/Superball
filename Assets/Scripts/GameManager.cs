using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class GameManager : MonoBehaviour
{
    #region General variables 
    
    public int enemyScore = 0;
    public int playerScore = 0;
    public float timer = 0;
    public int budget = 0;
    private bool isBestOfThree1,isBestOfThree2,isBestOfThree3,isBestOfThree4,isBestOfThree5,isBestOfThree6,
        isBestOfThree7,isBestOfThree8,isBestOfThree9,isBestOfThree10,isBestOfThree11,isBestOfThree12;
    public int LastLevel=0;
    public List<GameObject> usedButtons;
    private bool isPassedLevel1,isPassedLevel2,isPassedLevel3,isPassedLevel4,isPassedLevel5,isPassedLevel6,
        isPassedLevel7,isPassedLevel8,isPassedLevel9,isPassedLevel10,isPassedLevel11,isPassedLevel12;
    #endregion

    #region Texts

    [SerializeField] private Text enScoreText;
    [SerializeField] private Text plScoreText;
    [SerializeField] private Text timerText;
    [SerializeField] private Text countDownText;
    [SerializeField] private Text budgetText;
    [SerializeField] private Text levelText;
    
    #endregion

    #region Gameobjects
    
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ball;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject floor;
    [SerializeField] private GameObject square;
    [SerializeField] private Sprite freezeFloor;
    [SerializeField] private Sprite cityFloor;

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
    
    #region Unity Methods

    private void Start()
    {
        SpriteSetter();
        budget = PlayerPrefs.GetInt("Budget");
        LastLevel = PlayerPrefs.GetInt("Level");
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
        switch (LastLevel)
        {
            case 0:
                Button1.GetComponent<Button>().interactable = true;
                mainMenuPanel.SetActive(true);
                floor.GetComponent<SpriteRenderer>().sprite = cityFloor;
                square.GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case 1:
                Button1.GetComponent<Button>().interactable = true;
                Button2.GetComponent<Button>().interactable = true;
                floor.GetComponent<SpriteRenderer>().sprite = cityFloor;
                square.GetComponent<SpriteRenderer>().color = Color.green;
                mainMenuPanel.SetActive(true);
                isBestOfThree1 = true;

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
                isBestOfThree4 = true;
                isPassedLevel1 = true;
                isPassedLevel2 = true;
                isPassedLevel3 = true;
                isPassedLevel4 = true;
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
                isBestOfThree5= true;
                isPassedLevel1 = true;
                isPassedLevel2 = true;
                isPassedLevel3 = true;
                isPassedLevel4 = true;
                isPassedLevel4 = true;
                isPassedLevel5 = true;
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
                isBestOfThree6 = true;
                isPassedLevel1 = true;
                isPassedLevel2 = true;
                isPassedLevel3 = true;
                isPassedLevel4 = true;
                isPassedLevel4 = true;
                isPassedLevel5 = true;
                isPassedLevel6 = true;
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
                isBestOfThree7 = true;
                isPassedLevel1 = true;
                isPassedLevel2 = true;
                isPassedLevel3 = true;
                isPassedLevel4 = true;
                isPassedLevel4 = true;
                isPassedLevel5 = true;
                isPassedLevel6 = true;
                isPassedLevel7 = true;
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
                floor.GetComponent<SpriteRenderer>().sprite = freezeFloor;
                square.GetComponent<SpriteRenderer>().color = Color.blue;
                mainMenuPanel.SetActive(true);
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
                floor.GetComponent<SpriteRenderer>().sprite = freezeFloor;
                square.GetComponent<SpriteRenderer>().color = Color.blue;
                mainMenuPanel.SetActive(true);
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
                floor.GetComponent<SpriteRenderer>().sprite = freezeFloor;
                square.GetComponent<SpriteRenderer>().color = Color.blue;
                mainMenuPanel.SetActive(true);
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
                break;
            case 12:
                mainMenuPanel.SetActive(true);
                isBestOfThree12 = true;
                floor.GetComponent<SpriteRenderer>().sprite = freezeFloor;
                square.GetComponent<SpriteRenderer>().color = Color.blue;
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
            ms.ballSpriteRenderer.sprite = ms.ball1.sprite;
        }
        if (PlayerPrefs.GetInt("lastUsedBall") == 2)
        {
            ms. ballSpriteRenderer.sprite = ms.ball2.sprite;
        }
        if (PlayerPrefs.GetInt("lastUsedBall") == 3)
        {
            ms.ballSpriteRenderer.sprite = ms.ball3.sprite;    
        }
        if (PlayerPrefs.GetInt("lastUsedCar") == 1)
        {
                   ms. playerSpriteRenderer.sprite = ms.car1.sprite; 
        }
        if (PlayerPrefs.GetInt("lastUsedCar") == 2)
        {
                 ms. playerSpriteRenderer.sprite = ms.car2.sprite;   
        }
        if (PlayerPrefs.GetInt("lastUsedCar") == 3)
        {
                    ms.playerSpriteRenderer.sprite = ms.car3.sprite;
        }
    }

    void Update()
    {

        budgetText.text = PlayerPrefs.GetInt("Budget").ToString();
        levelText.text = PlayerPrefs.GetInt("Level").ToString();
        timer += Time.deltaTime;

        enScoreText.text = enemyScore.ToString();
        plScoreText.text = playerScore.ToString();
        timerText.text = Mathf.Floor(timer).ToString();

        if (timer >= 60f)  
        {
            // StopTheGame();
            if (playerScore > enemyScore)
            {
                winPanel.SetActive(true);
            }
            if(playerScore < enemyScore)
            {
                losePanel.SetActive(true);
            }
        }

       
        if (isBestOfThree1)
        {
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
                    LastLevel++;
                    isPassedLevel1 = true;
                }
                PlayerPrefs.SetInt("Level", LastLevel);
                isBestOfThree1 = isBestOfThree2 = isBestOfThree3 = isBestOfThree4 = isBestOfThree5 = isBestOfThree6 = 
                    isBestOfThree7 = isBestOfThree8 = isBestOfThree9 = isBestOfThree10 = isBestOfThree11 = isBestOfThree12 = false;
                Button2.GetComponent<Button>().interactable = true;
            }

            if (enemyScore == 3)
            {
                StopTheGame();
                losePanel.SetActive(true);
                freeze.SetActive(false);
                powerShot.SetActive(false);
            }
        }
        if (isBestOfThree2)
        {
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
                    LastLevel++;
                    isPassedLevel2 = true;
                }
                PlayerPrefs.SetInt("Level", LastLevel);

                isBestOfThree1 = isBestOfThree2 = isBestOfThree3 = isBestOfThree4 = isBestOfThree5 = isBestOfThree6 = 
                    isBestOfThree7 = isBestOfThree8 = isBestOfThree9 = isBestOfThree10 = isBestOfThree11 = isBestOfThree12 = false;
                
                Button3.GetComponent<Button>().interactable = true;
            }

            if (enemyScore == 3)
            {
                StopTheGame();
                losePanel.SetActive(true);
                isBestOfThree3 = false;
                freeze.SetActive(false);
                powerShot.SetActive(false);
            }
        }if (isBestOfThree3)
        {
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
                    LastLevel++;
                    isPassedLevel3 = true;
                }
                PlayerPrefs.SetInt("Level", LastLevel); 
                isBestOfThree1 = isBestOfThree2 = isBestOfThree3 = isBestOfThree4 = isBestOfThree5 = isBestOfThree6 = 
                    isBestOfThree7 = isBestOfThree8 = isBestOfThree9 = isBestOfThree10 = isBestOfThree11 = isBestOfThree12 = false;
                Button4.GetComponent<Button>().interactable = true;
            }

            if (enemyScore == 3)
            {
                StopTheGame();
                losePanel.SetActive(true);
                freeze.SetActive(false);
                powerShot.SetActive(false);
            }
        }if (isBestOfThree4)
        {
            if (playerScore == 4)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree5 = true;
                freeze.SetActive(false);
                powerShot.SetActive(false);
                if (!isPassedLevel4)
                {
                    LastLevel++;
                    isPassedLevel4 = true;
                }
                PlayerPrefs.SetInt("Level", LastLevel);
                
                isBestOfThree1 = isBestOfThree2 = isBestOfThree3 = isBestOfThree4 = isBestOfThree5 = isBestOfThree6 = isBestOfThree7 = 
                    isBestOfThree8 = isBestOfThree9 = isBestOfThree10 = isBestOfThree11 = isBestOfThree12 = false;
                Button5.GetComponent<Button>().interactable = true;
            }

            if (enemyScore == 3)
            {
                StopTheGame();
                losePanel.SetActive(true);
                freeze.SetActive(false);
                powerShot.SetActive(false);
            }
        }if (isBestOfThree5)
        {
            if (playerScore == 5)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree6 = true;
                freeze.SetActive(false);
                powerShot.SetActive(false);
                if (!isPassedLevel5)
                {
                    LastLevel++;
                    isPassedLevel5 = true;
                }
                PlayerPrefs.SetInt("Level", LastLevel); 

                isBestOfThree1 = isBestOfThree2 = isBestOfThree3 = isBestOfThree4 = isBestOfThree5 = isBestOfThree6 = 
                    isBestOfThree7 = isBestOfThree8 = isBestOfThree9 = isBestOfThree10 = isBestOfThree11 = isBestOfThree12 = false;
                Button6.GetComponent<Button>().interactable = true;
            }

            if (enemyScore == 3)
            {
                StopTheGame();
                losePanel.SetActive(true);
                freeze.SetActive(false);
                powerShot.SetActive(false);
            }
        }if (isBestOfThree6)
        {
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
                    LastLevel++;
                    isPassedLevel6 = true;
                }
                PlayerPrefs.SetInt("Level", LastLevel); 
                isBestOfThree1 = isBestOfThree2 = isBestOfThree3 = isBestOfThree4 = isBestOfThree5 = isBestOfThree6 = 
                    isBestOfThree7 = isBestOfThree8 = isBestOfThree9 = isBestOfThree10 = isBestOfThree11 = isBestOfThree12 = false;
                Button7.GetComponent<Button>().interactable = true;
            }

            if (enemyScore == 3)
            {
                StopTheGame();
                losePanel.SetActive(true);
                freeze.SetActive(false);
                powerShot.SetActive(false);
            }
        }if (isBestOfThree7)
        {
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
                    LastLevel++;
                    isPassedLevel7 = true;
                }
                PlayerPrefs.SetInt("Level", LastLevel);
                isBestOfThree1 = isBestOfThree2 = isBestOfThree3 = isBestOfThree4 = isBestOfThree5 = isBestOfThree6 = 
                    isBestOfThree7 = isBestOfThree8 = isBestOfThree9 = isBestOfThree10 = isBestOfThree11 = isBestOfThree12 = false;
                Button8.GetComponent<Button>().interactable = true;
            }

            if (enemyScore == 3)
            {
                StopTheGame();
                losePanel.SetActive(true);
                freeze.SetActive(false);
                powerShot.SetActive(false);
            }
        }if (isBestOfThree8)
        {
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
                    LastLevel++;
                    isPassedLevel8 = true;
                }
                PlayerPrefs.SetInt("Level", LastLevel); 
                
                isBestOfThree1 = isBestOfThree2 = isBestOfThree3 = isBestOfThree4 = isBestOfThree5 = isBestOfThree6 = 
                    isBestOfThree7 = isBestOfThree8 = isBestOfThree9 = isBestOfThree10 = isBestOfThree11 = isBestOfThree12 = false;
                Button9.GetComponent<Button>().interactable = true;
            }

            if (enemyScore == 3)
            {
                StopTheGame();
                losePanel.SetActive(true);
                freeze.SetActive(false);
                powerShot.SetActive(false);
            }
        }if (isBestOfThree9)
        {
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
                    LastLevel++;
                    isPassedLevel9 = true;
                }
                PlayerPrefs.SetInt("Level", LastLevel);
                isBestOfThree1 = isBestOfThree2 = isBestOfThree3 = isBestOfThree4 = isBestOfThree5 = isBestOfThree6 = 
                    isBestOfThree7 = isBestOfThree8 = isBestOfThree9 = isBestOfThree10 = isBestOfThree11 = isBestOfThree12 = false;
                Button10.GetComponent<Button>().interactable = true;
            }

            if (enemyScore == 3)
            {
                StopTheGame();
                losePanel.SetActive(true);
                freeze.SetActive(false);
                powerShot.SetActive(false);
            }
        }if (isBestOfThree10)
        {
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
                    LastLevel++;
                    isPassedLevel10 = true;
                }
                PlayerPrefs.SetInt("Level", LastLevel); 
                isBestOfThree1 = isBestOfThree2 = isBestOfThree3 = isBestOfThree4 = isBestOfThree5 = isBestOfThree6 = 
                    isBestOfThree7 = isBestOfThree8 = isBestOfThree9 = isBestOfThree10 = isBestOfThree11 = isBestOfThree12 = false;
                Button11.GetComponent<Button>().interactable = true;
            }

            if (enemyScore == 3)
            {
                StopTheGame();
                losePanel.SetActive(true);
                freeze.SetActive(false);
                powerShot.SetActive(false);
            }
        }if (isBestOfThree11)
        {
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
                    LastLevel++;
                    isPassedLevel11 = true;
                }
                PlayerPrefs.SetInt("Level", LastLevel);

                isBestOfThree1 = isBestOfThree2 = isBestOfThree3 = isBestOfThree4 = isBestOfThree5 = isBestOfThree6 = 
                    isBestOfThree7 = isBestOfThree8 = isBestOfThree9 = isBestOfThree10 = isBestOfThree11 = isBestOfThree12 = false;
                Button12.GetComponent<Button>().interactable = true;
            }

            if (enemyScore == 3)
            {
                StopTheGame();
                losePanel.SetActive(true);
                freeze.SetActive(false);
                powerShot.SetActive(false);
            }
        }if (isBestOfThree12)
        {
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
                    LastLevel++;
                    isPassedLevel12 = true;
                }
                PlayerPrefs.SetInt("Level", LastLevel); 
                isBestOfThree1 = isBestOfThree2 = isBestOfThree3 = isBestOfThree4 = isBestOfThree5 = isBestOfThree6 = 
                    isBestOfThree7 = isBestOfThree8 = isBestOfThree9 = isBestOfThree10 = isBestOfThree11 = isBestOfThree12 = false;
            }

            if (enemyScore == 3)
            {
                StopTheGame();
                losePanel.SetActive(true);
                freeze.SetActive(false);
                powerShot.SetActive(false);
            }
        }
        
        #region PlayerPrefs
        PlayerPrefs.SetInt("Budget", budget);
        PlayerPrefs.SetInt("Level", LastLevel);
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
        EnmeySkills.EnemyHaveFrezeer = true;
        EnmeySkills.enemyHavePowerShot = true;
        floor.GetComponent<SpriteRenderer>().sprite = cityFloor;
        square.GetComponent<SpriteRenderer>().color = Color.green;
        FrezeerSkill();
        PowerShootSkill();
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
        EnmeySkills.EnemyHaveFrezeer = false;
        EnmeySkills.enemyHavePowerShot = false;
     
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
        EnmeySkills.EnemyHaveFrezeer = false;
        EnmeySkills.enemyHavePowerShot = false;
       
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
        EnmeySkills.enemyHavePowerShot = false;
      
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
        EnmeySkills.enemyHavePowerShot = false;
       
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
        EnmeySkills.enemyHavePowerShot = false;
        
        isBestOfThree6 = true;
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
        EnmeySkills.enemyHavePowerShot = true;
        
        isBestOfThree7 = true;
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
     
        powerShot.SetActive(true);
        isBestOfThree8 = true;
        stm.isPowerUpSkillUnlocked = true;

    } 
    private void OnLevel9Click()
    {
        levelTreeDisplayPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        FrezeerSkill();
        PowerShootSkill();
        floor.GetComponent<SpriteRenderer>().sprite = freezeFloor;
        square.GetComponent<SpriteRenderer>().color = Color.blue;
        EnmeySkills.EnemyHaveFrezeer = true;
        EnmeySkills.enemyHavePowerShot = true;
       
        isBestOfThree9 = true;
    } 
    private void OnLevel10Click()
    {
        levelTreeDisplayPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        isBestOfThree10 = true;
        floor.GetComponent<SpriteRenderer>().sprite = freezeFloor;
        square.GetComponent<SpriteRenderer>().color = Color.blue;
        EnmeySkills.EnemyHaveFrezeer = true;
        EnmeySkills.enemyHavePowerShot = true;
       
        FrezeerSkill();
        PowerShootSkill();
    } private void OnLevel11Click()
    {
        levelTreeDisplayPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        FrezeerSkill();
        PowerShootSkill();
        floor.GetComponent<SpriteRenderer>().sprite = freezeFloor;
        square.GetComponent<SpriteRenderer>().color = Color.blue;
        EnmeySkills.EnemyHaveFrezeer = true;
        EnmeySkills.enemyHavePowerShot = true;
        
        isBestOfThree11 = true;
    } private void OnLevel12Click()
    {
        levelTreeDisplayPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        floor.GetComponent<SpriteRenderer>().sprite = freezeFloor;
        square.GetComponent<SpriteRenderer>().color = Color.blue;
        EnmeySkills.EnemyHaveFrezeer = true;
        EnmeySkills.enemyHavePowerShot = true;
       
        FrezeerSkill();
        PowerShootSkill();
        isBestOfThree12 = true;
    }
    #endregion
    

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
    }
    public void ButtonLevel2Controler()
    {
        OnLevel2Click();
    }

    public void ButtonLevel3Controler()
    {
        OnLevel3Click();
    }
    public void ButtonLevel4Controler()
    {
        OnLevel4Click();
    }
    public void ButtonLevel5Controler()
    {
        OnLevel5Click();
    }
    public void ButtonLevel6Controler()
    {
        OnLevel6Click();
    }
    public void ButtonLevel7Controler()
    {
        OnLevel7Click();
    }
    public void ButtonLevel8Controler()
    {
        OnLevel8Click();
    }
    public void ButtonLevel9Controler()
    {
        OnLevel9Click();
    }
    public void ButtonLevel10Controler()
    {
        OnLevel10Click();
    }
    public void ButtonLevel11Controler()
    {
        OnLevel11Click();
    }
    public void ButtonLevel12Controler()
    {
        OnLevel2Click();
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