using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public int origin = 0;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        Enemy enemy = other.GetComponent<Enemy>();
        PlayerHp playerHp = other.GetComponent<PlayerHp>();
        WallHp otherHp = other.GetComponent<WallHp>();

        if (playerHp != null)
        {
            playerHp.TakeDamage(1);
        }
        else if (enemy != null)
        {
            enemy.TakeDamage(1,origin);
        }
        else if (otherHp != null)
        {
            otherHp.TakeDamage(1);
        }
        
        gameObject.SetActive(false);
    }
}
