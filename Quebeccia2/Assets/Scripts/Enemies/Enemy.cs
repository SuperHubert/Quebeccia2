using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHp = 5;
    public int currentHp;

    public int scoreIncrease = 15;
    public int playOrder = 0;

    void Start()
    {
        currentHp = maxHp;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerHp playerHp = other.gameObject.GetComponent<PlayerHp>();

        if (playerHp != null)
        {
            playerHp.TakeDamage(1);
            WaveManager.Instance.KilledOpponent(gameObject);
            Destroy(gameObject);
        }
        
    }
    
    public void TakeDamage(int damage,int player)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            WaveManager.Instance.KilledOpponent(gameObject);
            ScoreManager.Instance.AddScore(player,scoreIncrease);
            Destroy(gameObject);
            
        }
    }
}

