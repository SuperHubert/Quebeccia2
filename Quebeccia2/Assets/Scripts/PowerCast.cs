using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerCast : MonoBehaviour
{
    private int yoink;
    public PlayerShoot pS;
    public GameObject droneX;
    private GameObject castShield;
    private GameObject castDroneX;
    private GameObject castY;
    private GameObject castB;
    public int shieldCooldown = 0;
    public int shieldCooldownMax = 300;
    public int droneXCooldown = 0;
    public int droneXCooldownMax = 300;
    public int yCooldown = 0;
    public int yCooldownMax = 300;
    public int bCooldown = 0;
    public int bCooldownMax = 300;
    public Image shieldCDImage;
    public Image droneXCDImage;
    public Image yCDImage;
    public Image bXCDImage;

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
        if (yCooldown > 0)
        {
            yCooldown--;
        }

        if (bCooldown > 0)
        {
            bCooldown--;
        }
        
    }

    private void Update()
    {
        ShieldAbility();
        
        DroneXAbility();

        YAbility();

        BAbility();
    }

    void ShieldAbility()
    {
        if (shieldCooldown <= 0)
        {
            if (pS.isPlayer1)
            {
                if (Input.GetButton("A Controller 1"))
                {
                    castShield = BulletPool.Instance.SpawnFromPool("Shields P1", new Vector3(transform.position.x + 2.5f, transform.position.y,0), Quaternion.identity);
                    castShield.layer = 6;
                    shieldCooldown = shieldCooldownMax;
                }
            }
            else
            {
                if (Input.GetButton("A Controller 2"))
                {
                    castShield = BulletPool.Instance.SpawnFromPool("Shields P2", new Vector3(transform.position.x - 2.5f, transform.position.y,0), Quaternion.identity);
                    castShield.layer = 7;
                    shieldCooldown = shieldCooldownMax;
                }
            }
        }
        else
        {
            shieldCDImage.fillAmount = (float) shieldCooldown / shieldCooldownMax;
        }
    }

    void DroneXAbility()
    {
        if (droneXCooldown <= 0)
        {
            if (pS.isPlayer1)
            {
                if (Input.GetButton("X Controller 1"))
                {
                    castDroneX = Instantiate(droneX, new Vector3(transform.position.x + 0.5f, transform.position.y,0), Quaternion.identity);
                    castDroneX.layer = 6;
                    droneXCooldown = droneXCooldownMax;
                }
            }
            else
            {
                if (Input.GetButton("X Controller 2"))
                {
                    castDroneX = Instantiate(droneX, new Vector3(transform.position.x - 0.5f, transform.position.y,0), Quaternion.identity);
                    castDroneX.layer = 7;
                    castShield.transform.Rotate(0,0,-180);
                    droneXCooldown = droneXCooldownMax;
                }
            }
        }
        else
        {
            droneXCDImage.fillAmount = (float) droneXCooldown / droneXCooldownMax;
        }
    }
    
    void YAbility()
    {
        if (yCooldown <= 0)
        {
            if (pS.isPlayer1)
            {
                if (Input.GetButton("Y Controller 1"))
                {
                    //castShield = Instantiate(droneX, new Vector3(transform.position.x + 0.5f, transform.position.y,0), Quaternion.identity);
                    //castShield.layer = 6;
                    yCooldown = yCooldownMax;
                }
            }
            else
            {
                if (Input.GetButton("Y Controller 2"))
                {
                    //castShield = Instantiate(droneX, new Vector3(transform.position.x - 0.5f, transform.position.y,0), Quaternion.identity);
                    //castShield.layer = 7;
                    yCooldown = yCooldownMax;
                }
            }
        }
        else
        {
            yCDImage.fillAmount = (float) yCooldown / yCooldownMax;
        }
    }
    
    void BAbility()
    {
        if (bCooldown <= 0)
        {
            if (pS.isPlayer1)
            {
                if (Input.GetButton("B Controller 1"))
                {
                    //castShield = Instantiate(droneX, new Vector3(transform.position.x + 0.5f, transform.position.y,0), Quaternion.identity);
                    //castShield.layer = 6;
                    bCooldown = bCooldownMax;
                }
            }
            else
            {
                if (Input.GetButton("B Controller 2"))
                {
                    //castShield = Instantiate(droneX, new Vector3(transform.position.x - 0.5f, transform.position.y,0), Quaternion.identity);
                    //castShield.layer = 7;
                    bCooldown = bCooldownMax;
                }
            }
        }
        else
        {
            bXCDImage.fillAmount = (float) bCooldown / bCooldownMax;
        }
    }
}
