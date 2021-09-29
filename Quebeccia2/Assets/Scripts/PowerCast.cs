using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerCast : MonoBehaviour
{
    public PlayerShoot pS;
    public GameObject shield;
    public GameObject castShield;
    public int shieldCooldown = 0;
    public int droneXCooldown = 0;
    public int cooldownMax = 300;
    public Image shieldImage;

    private void FixedUpdate()
    {
        droneXCooldown--;
        shieldCooldown--;
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
                    shieldCooldown = cooldownMax;
                }
            }
            else
            {
                if (Input.GetButton("A Controller 2"))
                {
                    castShield = Instantiate(shield, new Vector3(transform.position.x - 2.5f, transform.position.y,0), Quaternion.identity);
                    castShield.layer = 7;
                    shieldCooldown = cooldownMax;
                }
            }
        }
        else
        {
            shieldImage.fillAmount = (float) shieldCooldown / cooldownMax;
        }
        
        if (droneXCooldown <= 0)
        {
            if (pS.isPlayer1)
            {
                if (Input.GetButton("X Controller 1"))
                {
                    castShield = Instantiate(shield, new Vector3(transform.position.x + 2.5f, transform.position.y,0), Quaternion.identity);
                    castShield.layer = 6;
                    droneXCooldown = cooldownMax;
                }
            }
            else
            {
                if (Input.GetButton("X Controller 2"))
                {
                    castShield = Instantiate(shield, new Vector3(transform.position.x - 2.5f, transform.position.y,0), Quaternion.identity);
                    castShield.layer = 7;
                    droneXCooldown = cooldownMax;
                }
            }
        }
        else
        {
            shieldImage.fillAmount = (float) shieldCooldown / cooldownMax;
        }
    }
}
