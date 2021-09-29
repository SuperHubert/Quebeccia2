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
    public float invulFrames = 1;

    public Image lifeBar;
    

    void Start()
    {
        currentHp = startingHp;
    }
    
    public void TakeDamage(int damage)
    {
        if (canTakeDamage)
        {
            currentHp -= damage;
            StartCoroutine(InvulnerabilityFrames());
            if (currentHp <= 0)
            {
                currentHp = 0;
                Debug.Log("Game Over"); 
            }
            lifeBar.fillAmount = (float)currentHp / startingHp;
        }
        
    }

    IEnumerator InvulnerabilityFrames()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(invulFrames);
        canTakeDamage = true;
    }

}
