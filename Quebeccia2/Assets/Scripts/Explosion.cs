using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Collider range;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other);
    }
}
