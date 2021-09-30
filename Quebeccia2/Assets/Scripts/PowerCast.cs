using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerCast : MonoBehaviour
{
    public PlayerShoot pS;
    
    public GameObject droneX;
    public GameObject objectY;
    public GameObject objectB;
    
    public int costA = 1;
    private GameObject castShield;
    public int shieldCooldown = 0;
    public int shieldCooldownMax = 300;
    public Image shieldCDImage;
    
    public int costX = 1;
    private GameObject castDroneX;
    public int droneXCooldown = 0;
    public int droneXCooldownMax = 300;
    public Image droneXCDImage;
    
    public int costY = 1;
    private GameObject castY;
    public int yCooldown = 0;
    public int yCooldownMax = 300;
    public Image yCDImage;
    
    public int costB = 1;
    private GameObject castB;
    public int bCooldown = 0;
    public int bCooldownMax = 300;
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
                if (Input.GetButton("A Controller 1") && ScoreManager.Instance.HasRessources(1,costA))
                {
                    castShield = BulletPool.Instance.SpawnFromPool("Shields P1",
                        new Vector3(transform.position.x + 2.5f, transform.position.y, 0), Quaternion.identity);
                    castShield.layer = 6;
                    shieldCooldown = shieldCooldownMax;
                    ScoreManager.Instance.AddRessources(1,-1 * costA);
                }
            }
            else
            {
                if (Input.GetButton("A Controller 2") && ScoreManager.Instance.HasRessources(2,costA))
                {
                    castShield = BulletPool.Instance.SpawnFromPool("Shields P2", new Vector3(transform.position.x - 2.5f, transform.position.y,0), Quaternion.identity);
                    castShield.layer = 7;
                    shieldCooldown = shieldCooldownMax;
                    ScoreManager.Instance.AddRessources(2,-1 * costA);
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
                if (Input.GetButton("X Controller 1") && ScoreManager.Instance.HasRessources(1,costX))
                {
                    castDroneX = Instantiate(droneX, new Vector3(transform.position.x + 0.5f, transform.position.y,0), Quaternion.identity);
                    castDroneX.layer = 6;
                    droneXCooldown = droneXCooldownMax;
                    ScoreManager.Instance.AddRessources(1,-costX);
                }
            }
            else
            {
                if (Input.GetButton("X Controller 2") && ScoreManager.Instance.HasRessources(2,costX))
                {
                    castDroneX = Instantiate(droneX, new Vector3(transform.position.x - 0.5f, transform.position.y,0), Quaternion.identity);
                    castDroneX.layer = 7;
                    castDroneX.transform.Rotate(0, 0, -180);
                    droneXCooldown = droneXCooldownMax;
                    ScoreManager.Instance.AddRessources(2,-costX);
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
                if (Input.GetButton("Y Controller 1") && ScoreManager.Instance.HasRessources(1,costY))
                {
                    //castY = Instantiate(objectY, new Vector3(transform.position.x + 0.5f, transform.position.y,0), Quaternion.identity);
                    //castY.layer = 6;
                    yCooldown = yCooldownMax;
                    ScoreManager.Instance.AddRessources(1,-costY);
                }
            }
            else
            {
                if (Input.GetButton("Y Controller 2") && ScoreManager.Instance.HasRessources(2,costY))
                {
                    //castY = Instantiate(objectY, new Vector3(transform.position.x - 0.5f, transform.position.y,0), Quaternion.identity);
                    //castY.layer = 7;
                    yCooldown = yCooldownMax;
                    ScoreManager.Instance.AddRessources(2,-costY);
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
                if (Input.GetButton("B Controller 1") && ScoreManager.Instance.HasRessources(1,costB))
                {
                    //castB = Instantiate(objectB, new Vector3(transform.position.x + 0.5f, transform.position.y,0), Quaternion.identity);
                    //castB.layer = 6;
                    bCooldown = bCooldownMax;
                    ScoreManager.Instance.AddRessources(1,-costB);
                }
            }
            else
            {
                if (Input.GetButton("B Controller 2") && ScoreManager.Instance.HasRessources(2,costB))
                {
                    //castB = Instantiate(objectB, new Vector3(transform.position.x - 0.5f, transform.position.y,0), Quaternion.identity);
                    //castB.layer = 7;
                    bCooldown = bCooldownMax;
                    ScoreManager.Instance.AddRessources(2,-costB);
                }
            }
        }
        else
        {
            bXCDImage.fillAmount = (float) bCooldown / bCooldownMax;
        }
    }
}
