using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public Image lifeBarP1;
    public Image lifeBarP2;

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
                if (other.GetComponent<PlayerShoot>().isPlayer1)
                {
                    lifeBarP1.fillAmount = playerHp.currentHp / playerHp.startingHp;
                }
                else
                {
                    lifeBarP2.fillAmount = playerHp.currentHp / playerHp.startingHp;
                }
                if (playerHp.currentHp <= 0)
                {
                    Debug.Log("Game Over"); 
                }
            }
        }


    }
}
