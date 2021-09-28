using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyScriptableObject enemyInfo;

    private GameObject bullet;
    [SerializeField] private float shootCount = 0f;

    public int currentHp;
    
    void Start()
    {
        currentHp = enemyInfo.maxHp;
    }
    
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other);
        
        currentHp--;
        if (currentHp <= 0) {
            Destroy(gameObject);
            //ajoute un score jsp
        }

    }
}
