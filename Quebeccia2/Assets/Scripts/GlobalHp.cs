using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalHp : MonoBehaviour
{
    public float startingHp = 6;
    public float currentHp;
    public bool decay = false;
    public float decaySpeed = 0.1f;
    
    void Start()
    {
        currentHp = startingHp;
    }

    private void FixedUpdate()
    {
        if (decay)
        {
            currentHp -= decaySpeed;
            if (currentHp <= 0)
            {
                currentHp = 0;
                gameObject.SetActive(false);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            currentHp = 0;
            gameObject.SetActive(false);
        }
    }
        
}