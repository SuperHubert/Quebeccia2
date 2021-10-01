using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreToNextScene : MonoBehaviour
{
    #region Singleton
    public static ScoreToNextScene Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public int scoreP1;
    public int scoreP2;
    public int highScore;
    public bool newHighScore = false;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore",0);
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    public void UpdateScore()
    {
        scoreP1 = ScoreManager.Instance.player1Score;
        scoreP2 = ScoreManager.Instance.player2Score;
        
        if (scoreP1 > scoreP2 && scoreP1 > highScore)
        {
            highScore = scoreP1;
            PlayerPrefs.SetInt("HighScore", highScore);
            newHighScore = true;
        }
        if (scoreP2 > scoreP1 && scoreP2 > highScore)
        {
            highScore = scoreP1;
            PlayerPrefs.SetInt("HighScore", highScore);
            newHighScore = true;
        }
    }

    
    public string GetWinner()
    {
        if (scoreP1 > scoreP2)
        {
            return "Joueur 1";
        }
        else if (scoreP1 == scoreP2)
        {
            return "Aucun";
        }
        else
        {
            return "Joueur 2";
        }
    }
}
