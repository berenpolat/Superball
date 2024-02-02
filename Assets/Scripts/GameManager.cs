using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int enemyScore = 0;
    public int playerScore = 0;

    [SerializeField] private Text enScoreText;
    [SerializeField] private Text plScoreText;

    void Update()
    {
        enScoreText.text = enemyScore.ToString();
        plScoreText.text = playerScore.ToString();
    }
}
