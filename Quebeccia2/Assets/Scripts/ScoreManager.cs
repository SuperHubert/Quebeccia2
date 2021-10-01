using System;
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
    
    public int ressourceMax = 6;
    public int player1Ressources = 0;
    public int player2Ressources = 0;
    public Transform player1RessourceTransform;
    public Transform player2RessourceTransform;

    #region Singleton
    public static ScoreManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    private void Start()
    {
        UpdateUIP1();
        UpdateUIP2();
    }

    public void AddScore(int player, int score)
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

    public void AddRessources(int player, int number)
    {
        if (player == 1)
        {
            player1Ressources += number;
            if (player1Ressources > ressourceMax)
            {
                player1Ressources = ressourceMax;
            }
            UpdateUIP1();
            
        }
        else
        {
            player2Ressources += number;
            if (player2Ressources > ressourceMax)
            {
                player2Ressources = ressourceMax;
            }
            UpdateUIP2();
            
        }
    }
    
    public bool HasRessources(int player,int number = 1)
    {
        if (player == 1)
        {
            return (player1Ressources >= number);
        }
        else
        {
            return (player2Ressources >= number);
        }
    }

    void UpdateUIP1()
    {
        foreach (Transform child in player1RessourceTransform)
        {
            child.gameObject.SetActive(false);
        }

        for (int i = 0; i < player1Ressources; i++)
        {
            player1RessourceTransform.GetChild(i).gameObject.SetActive(true);
        }
    }

    void UpdateUIP2()
    {
        foreach (Transform child in player2RessourceTransform)
        {
            child.gameObject.SetActive(false);
        }

        for (int i = 0; i < player2Ressources; i++)
        {
            player2RessourceTransform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
