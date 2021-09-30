using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ScoreManager.Instance.AddRessources(1,1);
        }
    }
}
