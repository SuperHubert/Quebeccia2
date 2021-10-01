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
    }

    public void UpdateScore()
    {
        scoreP1 = ScoreManager.Instance.player1Score;
        scoreP2 = ScoreManager.Instance.player2Score;

    }
}
