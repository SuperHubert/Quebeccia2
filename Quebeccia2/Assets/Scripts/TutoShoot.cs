using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutoShoot : MonoBehaviour
{
    public TutoShoot foe;
    public GameObject bulletPrefab;
    [SerializeField] private int cooldown = 4;
    public int coolDownMax = 50;
    public bool isPlayer1;

    [SerializeField] float bulletSpeed = 10f;
    private BulletPool bulletPool;
    private GameObject bullet;

    public TextMeshProUGUI readyText;
    public bool isReady;
    private void Start()
    {
        bulletPool = BulletPool.Instance;
    }
    
    void Update()
    {
        if (cooldown > 0)
        {
            cooldown--;
        }
        
        if (isPlayer1)
        {
            if (Input.GetAxis("LT Controller 1") != 0 || Input.GetAxis("RT Controller 1") != 0 || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Q))
            {
                if (cooldown <= 0)
                {
                    ShootBullet();
                }
            }
        }
        else
        {
            if (Input.GetAxis("LT Controller 2") != 0 || Input.GetAxis("RT Controller 2") != 0 || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                if (cooldown <= 0)
                {
                    ShootBullet();
                }
            }
        }

        if (foe.isReady && isReady && isPlayer1)
        {
            SceneManager.LoadScene(1);
        }
        
    }

    void ShootBullet()
    {
        bullet = bulletPool.SpawnFromPool("Player Bullets", transform.position, Quaternion.identity);
        if (isPlayer1)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
            bullet.GetComponent<Bullet>().origin = 1;
            bullet.layer = 8;
            isReady = true;
            readyText.gameObject.SetActive(true);
        }
        else
        {
            bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed * -1;
            bullet.GetComponent<Bullet>().origin = 2;
            bullet.layer = 9;
            isReady = true;
            readyText.gameObject.SetActive(true);
        }
        
        cooldown = coolDownMax;
    }
}
