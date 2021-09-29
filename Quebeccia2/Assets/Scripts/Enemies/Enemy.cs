using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyScriptableObject enemyInfo;

    private GameObject bullet;
    [SerializeField] private int shootCount = 0;

    public bool canShoot = false;
    
    public int currentHp;

    void Start()
    {
        currentHp = enemyInfo.maxHp;
        
    }
    
    void Update()
    {
        if (enemyInfo.canShoot && canShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (shootCount > 0) 
        { 
            shootCount--;
        }
        else
        {
            bullet = Instantiate(enemyInfo.bullet, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = transform.right * enemyInfo.fireSpeed;
            bullet.layer = 10;
            Destroy(bullet,5);
            shootCount = enemyInfo.fireRate;
        }
    }
    
    public void TakeDamage(int damage,int player)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            WaveManager.Instance.KilledOpponent(gameObject);
            ScoreManager.Instance.AddScore(player,enemyInfo.scoreIncrease);
            Destroy(gameObject);
            
        }
    }
        
}

