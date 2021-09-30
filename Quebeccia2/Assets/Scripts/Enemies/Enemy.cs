using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject bullet;
    [SerializeField] private int shootCount = 0;

    public bool canShoot = false;
    
    public int maxHp = 5;
    public int currentHp;

    public int scoreIncrease = 15;

    void Start()
    {
        currentHp = maxHp;
    }
    
    void Update()
    {
        
    }

    /*
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
    */
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other);
        
        PlayerHp playerHp = other.gameObject.GetComponent<PlayerHp>();

        if (playerHp != null)
        {
            playerHp.TakeDamage(1);
            Destroy(gameObject);
        }
        
    }
    
    public void TakeDamage(int damage,int player)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            WaveManager.Instance.KilledOpponent(gameObject);
            ScoreManager.Instance.AddScore(player,scoreIncrease);
            Destroy(gameObject);
            
        }
    }
    
    
        
}

