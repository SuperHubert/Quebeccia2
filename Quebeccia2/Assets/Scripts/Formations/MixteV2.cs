using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixteV2 : MonoBehaviour
{
    public GameObject mainParent;
    public float mainSpeed = 1;
    public float timeSpent = 0;

    void Start()
    {
        mainParent = this.gameObject;
        mainParent.transform.position = Vector3.up * 10;
    }
    
    void Update()
    {
        if (mainParent.transform.position != Vector3.zero)
        {
            float step =  mainSpeed * Time.deltaTime;
            mainParent.transform.position = Vector3.MoveTowards(mainParent.transform.position, Vector3.zero, step);
        }
    }
}


