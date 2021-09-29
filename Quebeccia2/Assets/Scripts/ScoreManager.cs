using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int player1Score = 0;
    public int player2Score = 0;
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;

    #region Singleton
    public static ScoreManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion
    
    public void AddScore(int player, int score)
    {
        if (player != 0)
        {
            if (player == 1)
            {
                player1Score += score;
                player1ScoreText.text = "Score : " + player1Score;
            }
            else
            {
                player2Score += score;
                player2ScoreText.text = "Score : " + player2Score;
            }
        }
        
    }
}
