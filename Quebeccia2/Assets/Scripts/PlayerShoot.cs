using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    [SerializeField] private int cooldown = 50;

    void Update()
    {
        if (cooldown > 0)
        {
            cooldown--;
        }
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
        cooldown = 50;
    }
}
