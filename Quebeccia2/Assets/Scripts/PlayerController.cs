using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform playerObject;
    public float maxHeight = 4.75f;
    public float minHeight = -4.75f;
    public bool up;
    public bool down;
    public bool right;
    public bool left;

    [Range(0,100)]
    public float speed = 1;
    
    void Start()
    {
        
    }

    void Update()
    {
        //check inputs
        up = Input.GetKey(KeyCode.Z);
        down = Input.GetKey(KeyCode.S);
    }

    void FixedUpdate()
    {
        //bouge le vaisseau
        if (up)
        {
            if (playerObject.transform.position.y + speed * Time.deltaTime < maxHeight) 
            {
                playerObject.transform.position =
                    new Vector3(playerObject.transform.position.x,
                        playerObject.transform.position.y + speed * Time.deltaTime,
                        playerObject.transform.position.z);
            }   
        }
        if (down)
        {
            if (playerObject.transform.position.y + speed * Time.deltaTime > minHeight)
            {
                playerObject.transform.position =
                    new Vector3(playerObject.transform.position.x,
                        playerObject.transform.position.y - speed * Time.deltaTime,
                        playerObject.transform.position.z);
            }
        }
    }
}