using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    [SerializeField] private int cooldown = 4;
    public bool isPlayer1;

    [SerializeField] float bulletSpeed = 10f;
    private GameObject bullet;

    private void FixedUpdate()
    {
        if (cooldown > 0)
        {
            cooldown--;
        }

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (cooldown <= 0)
            {
                ShootBullet();
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
