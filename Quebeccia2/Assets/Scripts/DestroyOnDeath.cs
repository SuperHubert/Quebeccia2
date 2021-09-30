using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDeath : MonoBehaviour
{
    public GlobalHp gh;

    private void Update()
    {
        if (gh.currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
