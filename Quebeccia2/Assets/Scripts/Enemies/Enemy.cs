using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

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
        StartCoroutine(StartMoving(timeUntilActive+2.1f));

    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerHp playerHp = other.gameObject.GetComponent<PlayerHp>();

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
        active = true;
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
        }
    }
}

