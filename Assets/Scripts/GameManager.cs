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
    [SerializeField]private float yPos = -107.8f;
    private bool isClickable = true;
    public int LastLevel=0;
    public List<GameObject> shoppedGameObject;

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

    #endregion

    #region Panels

    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject ingamePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject marketPanel;
    [SerializeField] private GameObject skillTreePanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject freezeSkillTutorialPanel;
    [SerializeField] private GameObject powerShootTutorialPanel;
    #endregion
    
    #region Script Instances

    [SerializeField] private EnemyScript es;
    [SerializeField] private PlayerMovements pm;
    [SerializeField] private BallMovements bm;
    [SerializeField] private SkillTreeManager stm;
    #endregion

    #region Unity Methods

    private void Start()
    {
        budget = PlayerPrefs.GetInt("Budget");
        LastLevel = PlayerPrefs.GetInt("Level");
        StopTheGame();

        
        timer = 0;
        switch (LastLevel)
        {
            case 0:
                yPos = -107.8f;
                mainMenuPanel.SetActive(true);
                break;
            case 1:
                yPos = -99.8f;
                mainMenuPanel.SetActive(true);
                isBestOfThree1 = true;
                break;
            case 2:
                yPos = -91.8f;
                mainMenuPanel.SetActive(true);
                isBestOfThree2 = true;
                break;
            case 3:
                yPos = -83.8f;
                mainMenuPanel.SetActive(true);
                isBestOfThree3 = true;
                break;
            case 4:
                yPos = -75.8f;
                mainMenuPanel.SetActive(true);
                isBestOfThree4 = true;
                break;
            case 5:
                yPos = -67.8f;
                mainMenuPanel.SetActive(true);
                isBestOfThree5= true;
                break;
            case 6:
                yPos = -59.8f;
                mainMenuPanel.SetActive(true);
                isBestOfThree6 = true;
                break;
            case 7:
                yPos = -51.8f;
                mainMenuPanel.SetActive(true);
                isBestOfThree7 = true;
                break;
            case 8:
                yPos = -43.8f;
                mainMenuPanel.SetActive(true);
                isBestOfThree8 = true;
                break;
            case 9:
                yPos = -35.8f;
                mainMenuPanel.SetActive(true);
                isBestOfThree9 = true;
                break;
            case 10:
                yPos = -27.8f;
                mainMenuPanel.SetActive(true);
                isBestOfThree10 = true;
                break;
            case 11:
                yPos = -19.8f;
                mainMenuPanel.SetActive(true);
                isBestOfThree11 = true;
                break;
            case 12:
                yPos = -11.8f;
                mainMenuPanel.SetActive(true);
                isBestOfThree12 = true;
                break;
            default:
                OnLevel1Click();
                break;
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
                yPos+=8;
                freeze.SetActive(false);
                powerShot.SetActive(false);
                LastLevel++;
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
        if (isBestOfThree2)
        {
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree3 = true;
                yPos+=8;
                freeze.SetActive(false);
                powerShot.SetActive(false);
                LastLevel++; 
                PlayerPrefs.SetInt("Level", LastLevel);

                isBestOfThree1 = isBestOfThree2 = isBestOfThree3 = isBestOfThree4 = isBestOfThree5 = isBestOfThree6 = 
                    isBestOfThree7 = isBestOfThree8 = isBestOfThree9 = isBestOfThree10 = isBestOfThree11 = isBestOfThree12 = false;
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
                freezeSkillTutorialPanel.SetActive(true);
                budget += 300;
                isBestOfThree4 = true;
                yPos+=8;
                freeze.SetActive(false);
                powerShot.SetActive(false);
                LastLevel++;
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
        }if (isBestOfThree4)
        {
            if (playerScore == 4)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree5 = true;
                yPos+=8;
                freeze.SetActive(false);
                powerShot.SetActive(false);
                LastLevel++; 
                PlayerPrefs.SetInt("Level", LastLevel);
                
                isBestOfThree1 = isBestOfThree2 = isBestOfThree3 = isBestOfThree4 = isBestOfThree5 = isBestOfThree6 = isBestOfThree7 = 
                    isBestOfThree8 = isBestOfThree9 = isBestOfThree10 = isBestOfThree11 = isBestOfThree12 = false;
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
                yPos+=8;
                freeze.SetActive(false);
                powerShot.SetActive(false);
                LastLevel++;
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
        }if (isBestOfThree6)
        {
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree7 = true;
                yPos+=8;
                freeze.SetActive(false);
                powerShot.SetActive(false);
                LastLevel++; 
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
        }if (isBestOfThree7)
        {
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree8 = true;
                yPos+=8;
                freeze.SetActive(false);
                powerShot.SetActive(false);
                LastLevel++; 
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
        }if (isBestOfThree8)
        {
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                powerShootTutorialPanel.SetActive(true);
                budget += 300;
                isBestOfThree9 = true;
                yPos+=8;
                freeze.SetActive(false);
                powerShot.SetActive(false);
                LastLevel++;
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
        }if (isBestOfThree9)
        {
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree10 = true;
                yPos+=8;
                freeze.SetActive(false);
                powerShot.SetActive(false);
                LastLevel++; 
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
        }if (isBestOfThree10)
        {
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree11 = true;
                yPos+=8;
                freeze.SetActive(false);
                powerShot.SetActive(false);
                LastLevel++; 
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
        }if (isBestOfThree11)
        {
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree12 = true;
                yPos+=8;
                freeze.SetActive(false);
                powerShot.SetActive(false);
                LastLevel++; 
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
        }if (isBestOfThree12)
        {
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree1 = true;
                yPos+=8;
                freeze.SetActive(false);
                powerShot.SetActive(false);
                LastLevel++; 
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
        
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick();
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
        cam.transform.position = new Vector3(0, -0.2f, -10);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        isBestOfThree1 = true;
        EnmeySkills.EnemyHaveFrezeer = true;
        FrezeerSkill();
        PowerShootSkill();
    }
    private void OnLevel2Click()
    {
        cam.transform.position = new Vector3(0, -0.2f, -10);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        isBestOfThree2 = true;
        EnmeySkills.EnemyHaveFrezeer = false;
    }

    private void OnLevel3Click()
    {
        cam.transform.position = new Vector3(0, -0.2f, -10);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        isBestOfThree3 = true;
        EnmeySkills.EnemyHaveFrezeer = false;
    }
    private void OnLevel4Click()
    {
        cam.transform.position = new Vector3(0, -0.2f, -10);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        freeze.SetActive(true);
        FrezeerSkill();
        isBestOfThree4 = true;
        stm.isFreezeSkillUnlocked = true;
        EnmeySkills.EnemyHaveFrezeer = false;
    }
    private void OnLevel5Click()
    {
        cam.transform.position = new Vector3(0, -0.2f, -10);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        FrezeerSkill();
        EnmeySkills.EnemyHaveFrezeer = true;
        isBestOfThree5 = true;
    }
    private void OnLevel6Click()
    {
        cam.transform.position = new Vector3(0, -0.2f, -10);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        FrezeerSkill();
        EnmeySkills.EnemyHaveFrezeer = true;
        isBestOfThree6 = true;
    } 
    private void OnLevel7Click()
    {
        cam.transform.position = new Vector3(0, -0.2f, -10);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        FrezeerSkill();
        EnmeySkills.EnemyHaveFrezeer = true;
        isBestOfThree7 = true;
    }
    private void OnLevel8Click()
    {
        cam.transform.position = new Vector3(0, -0.2f, -10);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        FrezeerSkill();
        EnmeySkills.EnemyHaveFrezeer = true;
        powerShot.SetActive(true);
        isBestOfThree8 = true;
        stm.isPowerUpSkillUnlocked = true;

    } 
    private void OnLevel9Click()
    {
        cam.transform.position = new Vector3(0, -0.2f, -10);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        FrezeerSkill();
        PowerShootSkill();
        EnmeySkills.EnemyHaveFrezeer = true;
        isBestOfThree9 = true;
    } 
    private void OnLevel10Click()
    {
        cam.transform.position = new Vector3(0, -0.2f, -10);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        isBestOfThree10 = true;
        EnmeySkills.EnemyHaveFrezeer = true;
        FrezeerSkill();
        PowerShootSkill();
    } private void OnLevel11Click()
    {
        cam.transform.position = new Vector3(0, -0.2f, -10);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        FrezeerSkill();
        PowerShootSkill();
        EnmeySkills.EnemyHaveFrezeer = true;
        isBestOfThree11 = true;
    } private void OnLevel12Click()
    {
        cam.transform.position = new Vector3(0, -0.2f, -10);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        EnmeySkills.EnemyHaveFrezeer = true;
        FrezeerSkill();
        PowerShootSkill();
        isBestOfThree12 = true;
    }
    #endregion

    #region LevelTree Function

    public void DisplayLevelTree()
    {
        ingamePanel.SetActive(false);
        cam.transform.DOMove(new Vector3(0, yPos, -10),2f) ;
        mainMenuPanel.SetActive(false);
    }
    private void HandleClick()
    {
        Vector2 rayOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Level1"))
            {
                OnLevel1Click();
            }
            if (hit.collider.gameObject.CompareTag("Level2"))
            {
                OnLevel2Click();
            }
            if (hit.collider.gameObject.CompareTag("Level3"))
            {
                OnLevel3Click();
            }
            if (hit.collider.gameObject.CompareTag("Level4"))
            {
                OnLevel4Click();
            } if (hit.collider.gameObject.CompareTag("Level5"))
            {
                OnLevel5Click();
            } if (hit.collider.gameObject.CompareTag("Level6"))
            {
                OnLevel6Click();
            } if (hit.collider.gameObject.CompareTag("Level7"))
            {
                OnLevel7Click();
            } if (hit.collider.gameObject.CompareTag("Level8"))
            {
                OnLevel8Click();
            } if (hit.collider.gameObject.CompareTag("Level9"))
            {
                OnLevel9Click();
            } if (hit.collider.gameObject.CompareTag("Level10"))
            {
                OnLevel10Click();
            } if (hit.collider.gameObject.CompareTag("Level11"))
            {
                OnLevel11Click();
            } if (hit.collider.gameObject.CompareTag("Level12"))
            {
                OnLevel12Click();
            }
        }
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

    public void OpenMarket()
    {
        marketPanel.SetActive(true);
    }

    public void BackFromMarket()
    {
        marketPanel.SetActive(false);
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