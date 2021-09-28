using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public int startingHp = 6;
    public int currentHp;
    public bool canTakeDamage = true;

    public Image lifeBar;
    
    public Rigidbody2D rb;

    void Start()
    {
        currentHp = startingHp;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    public void TakeDamage(int damage)
    {
        if (canTakeDamage)
        {
            currentHp -= damage;
            if (currentHp <= 0)
            {
                currentHp = 0;
                Debug.Log("Game Over"); 
            }
            lifeBar.fillAmount = (float)currentHp / startingHp;
        }
        
    }
}
