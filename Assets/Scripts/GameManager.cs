using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int enemyScore = 0;
    public int playerScore = 0;
    public float timer = 0;  // Change the timer to a float to allow for fractions of a second

    [SerializeField] private Text enScoreText;
    [SerializeField] private Text plScoreText;
    [SerializeField] private Text timerText;

    void Update()
    {
        timer += Time.deltaTime;
        
        enScoreText.text = enemyScore.ToString();
        plScoreText.text = playerScore.ToString();
        timerText.text = Mathf.Floor(timer).ToString(); 
    }
}