using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int player1Score = 0;
    public int player2Score = 0;

    #region Singleton
    public static ScoreManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion
    
    public void AddScore(int player, int score)
    {
        if (player == 1)
        {
            player1Score += score;
        }
        else
        {
            player2Score += score;
        }
    }
}
