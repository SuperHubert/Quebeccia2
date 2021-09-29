using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCollide : MonoBehaviour
{
    public GameObject explosion;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
