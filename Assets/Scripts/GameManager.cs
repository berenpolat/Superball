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

    private float yPos = -107.8f;
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
        StopTheGame();
        timer = 0;
    }

    void Update()
    {
        budgetText.text = budget.ToString();
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
            //KAZANDI BUDGET VER
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree2 = true;
                yPos+=8;
                freeze.SetActive(false);
                powerShot.SetActive(false);
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
            //KAZANDI BUDGET VER
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree3 = true;
                yPos+=8;
                freeze.SetActive(false);
                powerShot.SetActive(false);
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
            //KAZANDI BUDGET VER
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree4 = true;
                yPos+=8;
                freeze.SetActive(false);
                powerShot.SetActive(false);
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
            //KAZANDI BUDGET VER
            if (playerScore == 4)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree5 = true;
                yPos+=8;
                freeze.SetActive(false);
                powerShot.SetActive(false);
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
            //KAZANDI BUDGET VER
            if (playerScore == 5)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree6 = true;
                yPos+=8;
                freeze.SetActive(false);
                powerShot.SetActive(false);
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
            //KAZANDI BUDGET VER
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree7 = true;
                yPos+=8;
                freeze.SetActive(false);
                powerShot.SetActive(false);
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
            //KAZANDI BUDGET VER
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree8 = true;
                yPos+=8;
                freeze.SetActive(false);
                powerShot.SetActive(false);
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
            //KAZANDI BUDGET VER
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree9 = true;
                yPos+=8;
                freeze.SetActive(false);
                powerShot.SetActive(false);
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
            //KAZANDI BUDGET VER
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree10 = true;
                yPos+=8;
                freeze.SetActive(false);
                powerShot.SetActive(false);
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
            //KAZANDI BUDGET VER
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree11 = true;
                yPos+=8;
                freeze.SetActive(false);
                powerShot.SetActive(false);
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
            //KAZANDI BUDGET VER
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree12 = true;
                yPos+=8;
                freeze.SetActive(false);
                powerShot.SetActive(false);
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
            //KAZANDI BUDGET VER
            if (playerScore == 3)
            {
                StopTheGame();
                winPanel.SetActive(true);
                budget += 300;
                isBestOfThree1 = true;
                yPos+=8;
                freeze.SetActive(false);
                powerShot.SetActive(false);
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
    }

    #endregion

    #region Skills variables
    [SerializeField] private GameObject freeze;
    [SerializeField] private GameObject powerShot;
    [SerializeField] private Button  FrezeerButton;
    [SerializeField] private Button PowerShotbutton;
    #endregion

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
            if (hit.collider.gameObject.CompareTag("Level2") && isBestOfThree1)
            {
                OnLevel2Click();
            }
            if (hit.collider.gameObject.CompareTag("Level3") && isBestOfThree2)
            {
                OnLevel3Click();
            }
            if (hit.collider.gameObject.CompareTag("Level4")&& isBestOfThree3)
            {
                OnLevel4Click();
            } if (hit.collider.gameObject.CompareTag("Level5")&& isBestOfThree4)
            {
                OnLevel5Click();
            } if (hit.collider.gameObject.CompareTag("Level6")&& isBestOfThree5)
            {
                OnLevel6Click();
            } if (hit.collider.gameObject.CompareTag("Level7")&& isBestOfThree6)
            {
                OnLevel7Click();
            } if (hit.collider.gameObject.CompareTag("Level8")&& isBestOfThree7)
            {
                OnLevel8Click();
            } if (hit.collider.gameObject.CompareTag("Level9")&& isBestOfThree8)
            {
                OnLevel9Click();
            } if (hit.collider.gameObject.CompareTag("Level10")&& isBestOfThree9)
            {
                OnLevel10Click();
            } if (hit.collider.gameObject.CompareTag("Level11")&& isBestOfThree10)
            {
                OnLevel11Click();
            } if (hit.collider.gameObject.CompareTag("Level12")&& isBestOfThree11)
            {
                OnLevel12Click();
            }
        }
    }

    #region Level Functions

    private void OnLevel1Click()
    {
        cam.transform.position = new Vector3(0, -0.2f, -10);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        isBestOfThree1 = true;
        FrezeerSkill();
        PowerShootSkill();
        LastLevel = 1;
    }
    private void OnLevel2Click()
    {
        cam.transform.position = new Vector3(0, -0.2f, -10);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        isBestOfThree2 = true;
        LastLevel = 2;
       
    }

    private void OnLevel3Click()
    {
        cam.transform.position = new Vector3(0, -0.2f, -10);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        isBestOfThree3 = true;
        LastLevel = 3;
    }
    private void OnLevel4Click()
    {
        cam.transform.position = new Vector3(0, -0.2f, -10);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        freeze.SetActive(true);
        isBestOfThree4 = true;
        stm.isFreezeSkillUnlocked = true;
        LastLevel = 4;
    }
    private void OnLevel5Click()
    {
        cam.transform.position = new Vector3(0, -0.2f, -10);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        FrezeerSkill();
        isBestOfThree5 = true;
        LastLevel = 5;
    }
    private void OnLevel6Click()
    {
        cam.transform.position = new Vector3(0, -0.2f, -10);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        FrezeerSkill();
        isBestOfThree6 = true;
        LastLevel = 6;
    } 
    private void OnLevel7Click()
    {
        cam.transform.position = new Vector3(0, -0.2f, -10);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        FrezeerSkill();
        isBestOfThree7 = true;
        LastLevel = 7;
    }
    private void OnLevel8Click()
    {
        cam.transform.position = new Vector3(0, -0.2f, -10);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        FrezeerSkill();
        powerShot.SetActive(true);
        isBestOfThree8 = true;
        stm.isPowerUpSkillUnlocked = true;
        LastLevel = 8;
    } 
    private void OnLevel9Click()
    {
        cam.transform.position = new Vector3(0, -0.2f, -10);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        FrezeerSkill();
        PowerShootSkill();
        isBestOfThree9 = true;
        LastLevel = 9;
    } 
    private void OnLevel10Click()
    {
        cam.transform.position = new Vector3(0, -0.2f, -10);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        isBestOfThree10 = true;
        FrezeerSkill();
        PowerShootSkill();
        LastLevel = 10;
    } private void OnLevel11Click()
    {
        cam.transform.position = new Vector3(0, -0.2f, -10);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        FrezeerSkill();
        PowerShootSkill();
        isBestOfThree11 = true;
        LastLevel = 11;
    } private void OnLevel12Click()
    {
        cam.transform.position = new Vector3(0, -0.2f, -10);
        mainMenuPanel.SetActive(false);
        StartCountdown();
        timer = 0;
        FrezeerSkill();
        PowerShootSkill();
        isBestOfThree12 = true;
        LastLevel = 12;
    }
    #endregion
   
    public void DisplayLevelTree()
    {
        ingamePanel.SetActive(false);
        cam.transform.DOMove(new Vector3(0, yPos, -10),2f) ;
        mainMenuPanel.SetActive(false);
    }
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
        ingamePanel.SetActive(true);
        enemy.SetActive(true);
        player.SetActive(true);
        ball.SetActive(true);
    }

    
    private void StartCountdown()
    {
        StartCoroutine(CountdownCoroutine());
    }

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

}