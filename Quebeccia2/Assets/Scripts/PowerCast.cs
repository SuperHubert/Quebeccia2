using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerCast : MonoBehaviour
{
    private int yoink;
    public PlayerShoot pS;
    public GameObject shield;
    public GameObject droneX;
    private GameObject castShield;
    private GameObject castDroneX;
    public int shieldCooldown = 0;
    public int shieldCooldownMax = 300;
    public int droneXCooldown = 0;
    public int droneXCooldownMax = 300;
    public int YCooldown = 0;
    public int YdCooldownMax = 300;
    public int BCooldown = 0;
    public int BCooldownMax = 300;
    public Image shieldCDImage;
    public Image DroneXCDImage;
    public Image YCDImage;
    public Image BXCDImage;

    private void FixedUpdate()
    {
        if (droneXCooldown > 0)
        {
            droneXCooldown--;
        }

        if (shieldCooldown > 0)
        {
            shieldCooldown--;
        }
        
    }

    private void Update()
    {
        if (shieldCooldown <= 0)
        {
            if (pS.isPlayer1)
            {
                if (Input.GetButton("A Controller 1"))
                {
                    castShield = Instantiate(shield, new Vector3(transform.position.x + 2.5f, transform.position.y,0), Quaternion.identity);
                    castShield.layer = 6;
                    shieldCooldown = shieldCooldownMax;
                }
            }
            else
            {
                if (Input.GetButton("A Controller 2"))
                {
                    castShield = Instantiate(shield, new Vector3(transform.position.x - 2.5f, transform.position.y,0), Quaternion.identity);
                    castShield.layer = 7;
                    shieldCooldown = shieldCooldownMax;
                }
            }
        }
        else
        {
            shieldCDImage.fillAmount = (float) shieldCooldown / shieldCooldownMax;
        }
        
        if (droneXCooldown <= 0)
        {
            if (pS.isPlayer1)
            {
                if (Input.GetButton("X Controller 1"))
                {
                    castShield = Instantiate(droneX, new Vector3(transform.position.x + 0.5f, transform.position.y,0), Quaternion.identity);
                    castShield.layer = 6;
                    droneXCooldown = droneXCooldownMax;
                }
            }
            else
            {
                if (Input.GetButton("X Controller 2"))
                {
                    castShield = Instantiate(droneX, new Vector3(transform.position.x - 0.5f, transform.position.y,0), Quaternion.identity);
                    castShield.layer = 7;
                    droneXCooldown = droneXCooldownMax;
                }
            }
        }
        else
        {
            DroneXCDImage.fillAmount = (float) droneXCooldown / droneXCooldownMax;
        }
    }
}
