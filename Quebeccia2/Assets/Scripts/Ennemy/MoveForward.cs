using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 0.1f;
    public bool p1target = true;
    public bool canMove = false;

    private void Start()
    {
        StartCoroutine(AutoKill());
    }

    void Update()
    {
        if (!canMove) return;
        float step =  speed * Time.deltaTime;
        if (p1target)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.left * 10, step);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.left * -10, step);
        }
    }

    IEnumerator AutoKill()
    {
        yield return new WaitForSeconds(10);
        WaveManager.Instance.KilledOpponent(gameObject);
        Destroy(gameObject);
    }
    
    
}
