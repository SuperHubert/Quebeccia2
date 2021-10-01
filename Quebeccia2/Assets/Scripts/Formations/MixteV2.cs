using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixteV2 : MonoBehaviour
{
    public GameObject mainParent;
    public float mainSpeed = 1;
    public bool startedMoving = false;

    void Start()
    {
        mainParent = this.gameObject;
        mainParent.transform.position = Vector3.up * 10;
    }
    
    void Update()
    {
        if (mainParent.transform.position != Vector3.zero && !startedMoving)
        {
            float step =  mainSpeed * Time.deltaTime;
            mainParent.transform.position = Vector3.MoveTowards(mainParent.transform.position, Vector3.zero, step);
        }
        else if (mainParent.transform.position == Vector3.zero && !startedMoving)
        {
            startedMoving = true;
            ActivateUnits();
        }
    }

    void ActivateUnits()
    {
        foreach (Transform side in transform)
        {
            foreach (Transform child in side)
            {
                child.GetComponent<Enemy>().Activate();
            }
        }
    }
}


