using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHp = 5;
    public int currentHp;

    public int scoreIncrease = 15;
    public int ressourceIncrease = 1;
    [Tooltip("Une seule décimale après la virgule s.v.p")]
    public float timeUntilActive = 1;

    public bool active = false;

    void Start()
    {
        currentHp = maxHp;
    }
    
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerHp playerHp = other.gameObject.GetComponent<PlayerHp>();

        if (other.gameObject.GetComponent<WallHp>())
        {
            WaveManager.Instance.KilledOpponent(gameObject);
            Destroy(gameObject); 
        }
        
        if (playerHp != null)
        {
            playerHp.TakeDamage(1);
            WaveManager.Instance.KilledOpponent(gameObject);
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
            ScoreManager.Instance.AddRessources(player,ressourceIncrease);
            Destroy(gameObject);
            
        }
    }

    public void Activate()
    {
        StartCoroutine(StartMoving(timeUntilActive));
    }
    
    IEnumerator StartMoving(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (gameObject.GetComponent<MoveForward>())
        {
            gameObject.GetComponent<MoveForward>().canMove = true;
        }
        else if (gameObject.GetComponent<BackAndForth>())
        {
            gameObject.GetComponent<BackAndForth>().canMove = true;
        }
                    
        if (gameObject.GetComponent<Shooter>())
        {
            gameObject.GetComponent<Shooter>().canShoot = true;
            gameObject.transform.parent = null;
        }
    }
}

