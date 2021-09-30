using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private int cooldown = 4;
    public int coolDownMax = 50;

    public bool canShoot;
    
    [SerializeField] float bulletSpeed = 10f;
    private BulletPool bulletPool;
    private GameObject bullet;

    private bool lookAtPlayer = false;
    public Vector3 target;
    
    void Update()
    {
        if (canShoot)
        {
            Shoot(); 
        }
        
    }

    void Shoot()
    {
        if (cooldown > 0) 
        { 
            cooldown--;
        }
        else
        {
            bullet = BulletPool.Instance.SpawnFromPool("Enemy Bullets", transform.position, Quaternion.identity);;
            bullet.GetComponent<Rigidbody2D>().velocity = transform.forward * bulletSpeed;
            bullet.layer = 10;
            cooldown = coolDownMax;
        }
    }
    
}
