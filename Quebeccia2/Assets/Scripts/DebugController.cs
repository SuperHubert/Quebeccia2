using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ScoreManager.Instance.AddRessources(1,6);
            ScoreManager.Instance.AddRessources(2,6);
        }
    }
}
