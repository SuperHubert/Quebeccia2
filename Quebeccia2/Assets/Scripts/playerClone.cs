using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerClone : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        GetComponent<PlayerShoot>().isPlayer1 = player.GetComponent<PlayerShoot>().isPlayer1;
    }

    void FixedUpdate()
    {
        gameObject.layer = player.layer;
        transform.position = new Vector3(transform.position.x,-player.transform.position.y,0);
    }
}