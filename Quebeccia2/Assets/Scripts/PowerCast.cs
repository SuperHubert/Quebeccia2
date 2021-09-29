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
    public int cooldown = 300;
    public int cooldownMax = 300;
    public Image shieldImage;

    private void FixedUpdate()
    {

        if (cooldown > 0)
        {
            cooldown--;
        }

    }

    private void Update()
    {
        if (cooldown <= 0)
        {
            if (pS.isPlayer1)
            {
                if (Input.GetButton("A Controller 1"))
                {
                    castShield = Instantiate(shield, new Vector3(transform.position.x + 2.5f, transform.position.y,0), Quaternion.identity);
                    castShield.layer = 6;
                    cooldown = cooldownMax;
                }
            }
            else
            {
                if (Input.GetButton("A Controller 2"))
                {
                    castShield = Instantiate(shield, new Vector3(transform.position.x - 2.5f, transform.position.y,0), Quaternion.identity);
                    castShield.layer = 7;
                    cooldown = cooldownMax;
                }
            }
        }
        else
        {
            shieldImage.fillAmount = (float) cooldown / cooldownMax;
        }
    }
}
