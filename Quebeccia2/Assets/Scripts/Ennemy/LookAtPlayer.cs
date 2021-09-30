using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public bool lookAtPlayer1;
    private Transform player;
    void Start()
    {
        if (lookAtPlayer1)
        {
            player = ScoreManager.Instance.gameObject.GetComponent<PlayerController>().player1Object;
        }
        else
        {
            player = ScoreManager.Instance.gameObject.GetComponent<PlayerController>().player2Object;
        }
    }
    
    void Update()
    {
        transform.LookAt(player,Vector3.forward);
    }
}
