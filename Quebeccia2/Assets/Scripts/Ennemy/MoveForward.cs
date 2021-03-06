using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 0.1f;
    public bool p1target = true;
    public bool asTarget = false;
    public bool targetPlayerPos = false;
    public bool targetPlayer1 = false;
    public Vector3 target;
    private bool canLook = true;
    public bool canMove = false;

    private void Start()
    {
        StartCoroutine(AutoKill());
        if (targetPlayerPos)
        {
            if (targetPlayer1)
            {
                target = ScoreManager.Instance.gameObject.GetComponent<PlayerController>().player1Object.position;
            }
            else
            {
                target = ScoreManager.Instance.gameObject.GetComponent<PlayerController>().player2Object.position;
            }
        }
    }

    void Update()
    {
        if (canLook && asTarget)
        {
            transform.LookAt(target,Vector3.forward);
        }

        if (canMove)
        {
            canLook = false;

            float step = speed * Time.deltaTime;

            if (asTarget)
            {
                transform.position += transform.forward * step;
            }
            else if (p1target)
            {
                transform.position =
                    Vector3.MoveTowards(transform.position, transform.position + Vector3.left * 10, step);
            }
            else
            {
                transform.position =
                    Vector3.MoveTowards(transform.position, transform.position + Vector3.left * -10, step);
            }

        }

    }

    IEnumerator AutoKill()
    {
        yield return new WaitForSeconds(10);
        WaveManager.Instance.KilledOpponent(gameObject);
        Destroy(gameObject);
    }
    
    
}
