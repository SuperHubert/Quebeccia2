using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform player1Object;
    public Transform player2Object;
    private Rigidbody2D player1rb;
    private Rigidbody2D player2rb;
    public float maxHeight = 4.75f;
    [Range(0f,1f)]public float axeMargin = 0.5f;
    public float player1Axis;
    public float player2Axis;

    [Range(0,100)]
    public float speed = 1;
    
    void Start()
    {
        player1rb = player1Object.GetComponent<Rigidbody2D>();
        player2rb = player2Object.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //check inputs
        player1Axis = AxisMargin(Input.GetAxis("Vertical Controller 1"));
        player2Axis = AxisMargin(Input.GetAxis("Vertical Controller 2"));

    }

    void FixedUpdate()
    {
        player1rb.MovePosition(player1rb.position + Vector2.down * speed * Time.deltaTime * player1Axis);
        player2rb.MovePosition(player2rb.position + Vector2.down * speed * Time.deltaTime * player2Axis);
        
        //player1Object.localPosition += Vector3.down * speed * Time.deltaTime * player1Axis;
        //player2Object.localPosition += Vector3.down * speed * Time.deltaTime * player2Axis;
        
        /*
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
            if (playerObject.transform.position.y + speed * Time.deltaTime > -maxHeight)
            {
                playerObject.transform.position =
                    new Vector3(playerObject.transform.position.x,
                        playerObject.transform.position.y - speed * Time.deltaTime,
                        playerObject.transform.position.z);
            }
        }
        */
    }

    float AxisMargin(float input,float max = 0.5f)
    {
        if (input > max || input < -max)
        {
            return input;
        }
        else
        {
            return 0f;
        }
        
    }
}