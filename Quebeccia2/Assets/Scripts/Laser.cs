using System;
using System.Collections;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject player;
    public bool expand;
    public float targetScale = 0.8f;
    public bool attackTime;
    public int laserDamage;
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
            if (transform.localScale.y >= targetScale)
            {
                expand = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (attackTime)
        {
            GetComponent<MeshRenderer>().material = laserShooting;
            
            if (other.GetComponent<Enemy>())
            {
                other.GetComponent<Enemy>().TakeDamage(laserDamage,player.layer-5);
            }
            else if (other.GetComponent<PlayerHp>())
            {
                other.GetComponent<PlayerHp>().TakeDamage(laserDamage);
            }
            else if (other.GetComponent<GlobalHp>())
            {
                other.GetComponent<GlobalHp>().TakeDamage(laserDamage);
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
