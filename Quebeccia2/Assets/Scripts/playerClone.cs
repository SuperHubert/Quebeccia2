using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerClone : MonoBehaviour
{
    public GameObject player;

    void FixedUpdate()
    {
        gameObject.layer = player.layer;
        transform.position = new Vector3(transform.position.x,-player.transform.position.y,0);
    }
}
