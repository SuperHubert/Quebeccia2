using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallHp : MonoBehaviour
{
    public float startingHp = 6;
    public float currentHp;
    public bool decay = false;

    public Image lifeBar;
    
    public Rigidbody2D rb;

    void Start()
    {
        if (decay)
        {
            currentHp = startingHp;
        }
    }

    private void FixedUpdate()
    {
        currentHp -= 0.1f;
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            currentHp = 0;
            Destroy(gameObject);
        }
    }
        
}