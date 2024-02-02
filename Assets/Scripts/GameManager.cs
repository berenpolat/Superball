using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    
    #region General variables 
    
    public int enemyScore = 0;
    public int playerScore = 0;
    public float timer = 0;

    #endregion

    #region Texts

    [SerializeField] private Text enScoreText;
    [SerializeField] private Text plScoreText;
    [SerializeField] private Text timerText;

    #endregion

    #region Unity Methods

    void Update()
    {
        timer += Time.deltaTime;
        
        enScoreText.text = enemyScore.ToString();
        plScoreText.text = playerScore.ToString();
        timerText.text = Mathf.Floor(timer).ToString(); 
    }

    #endregion
    
   
}