using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    [SerializeField] private int cooldown = 4;

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
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        cooldown = 4;
    }
}
