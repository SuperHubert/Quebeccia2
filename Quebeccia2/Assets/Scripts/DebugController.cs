using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Controller 2 :"+Input.GetAxis("Vertical Controller 2"));
        Debug.Log("Controller 1 :"+Input.GetAxis("RT Controller 1"));
    }
}
