using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    [SerializeField] private int cooldown = 4;
    public bool isPlayer1;

    [SerializeField] float bulletSpeed = 10f;
    private BulletPool bulletPool;
    private GameObject bullet;
    
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
            if (Input.GetAxis("LT Controller 1") != 0 || Input.GetAxis("RT Controller 1") != 0)
            {
                if (cooldown <= 0)
                {
                    ShootBullet();
                }
            }
        }
        else
        {
            //if (Input.GetAxis("LT Controller 2") != 0 || Input.GetAxis("RT Controller 2") != 0)
            if(Input.GetKey(KeyCode.A))
            {
                if (cooldown <= 0)
                {
                    ShootBullet();
                }
            }
        }
        
    }

    void ShootBullet()
    {
        bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        if (isPlayer1)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
            bullet.layer = 8;
        }
        else
        {
            bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed * -1;
            bullet.layer = 9;
        }
        
        cooldown = 4;
    }
}
