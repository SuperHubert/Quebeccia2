using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneXDamage : MonoBehaviour
{
    public int playerDamage = 10;
    public int shieldDamage = 50;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHp playerHp = other.gameObject.GetComponent<PlayerHp>();

        if (playerHp != null)
        {
            playerHp.TakeDamage(playerDamage);
            WaveManager.Instance.KilledOpponent(gameObject);
            gameObject.transform.parent.gameObject.SetActive(false);
        }

        if (other.gameObject.GetComponent<GlobalHp>())
        {
            other.gameObject.GetComponent<GlobalHp>().TakeDamage(shieldDamage);
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}
