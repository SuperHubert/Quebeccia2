using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCollide : MonoBehaviour
{
    public GameObject explosion;
    private void OnCollisionEnter(Collision other)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
