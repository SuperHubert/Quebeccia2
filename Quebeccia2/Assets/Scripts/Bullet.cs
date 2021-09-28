using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        
        if (enemy != null)
        {
            enemy.currentHp--;
            if (enemy.currentHp <= 0)
            {
                Destroy(enemy.gameObject);
                gameObject.SetActive(false);
            }
        }
        else
        {
            PlayerHp playerHp = other.GetComponent<PlayerHp>();
            if (playerHp != null)
            {
                playerHp.currentHp--;
                if (playerHp.currentHp <= 0)
                {
                    Debug.Log("Game Over"); 
                }
            }
        }


    }
}
