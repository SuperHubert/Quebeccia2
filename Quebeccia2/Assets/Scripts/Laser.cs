using System;
using System.Collections;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject player;
    public bool expand;
    public float targetScale = 0.8f;
    public bool attackTime;
    public Material laserShooting;

    private void Start()
    {
        gameObject.layer = player.layer;
        expand = false;
        attackTime = false;
        StartCoroutine("LaserLife");
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, player.transform.position.y, 0);
        
        if (expand)
        {
            transform.localScale += new Vector3(0, 0.025f, 0);
            Debug.Log("expand");
            if (transform.localScale.y >= targetScale)
            {
                Debug.Log("targeted scale");
                expand = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        PlayerHp playerHp = other.GetComponent<PlayerHp>();
        GlobalHp otherHp = other.GetComponent<GlobalHp>();
        
        if (attackTime == true)
        {
            GetComponent<MeshRenderer>().material = laserShooting;
            if (playerHp != null)
            {
                playerHp.TakeDamage(5);
            }
            else if (enemy != null)
            {
                enemy.TakeDamage(5, 0);
            }
            else if (otherHp != null)
            {
                otherHp.TakeDamage(5);
            }
            
            attackTime = false;
        }
    }

    IEnumerator LaserLife()
    {
        yield return new WaitForSeconds(2f);
        expand = true;
        attackTime = true;
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
