using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixteV2 : MonoBehaviour
{
    public GameObject mainParent;
    public float mainSpeed = 1;
    public int phase = 0;
    
    void Start()
    {
        mainParent = this.gameObject;
        mainParent.transform.position = Vector3.up * 10;
    }
    
    void Update()
    {
        if (phase == 0)
        {
            float step =  mainSpeed * Time.deltaTime;
            mainParent.transform.position = Vector3.MoveTowards(mainParent.transform.position, Vector3.zero, step);
        }

        if (mainParent.transform.position == Vector3.zero)
        {
            phase++;
            foreach (Transform branch in mainParent.transform)
            {
                foreach (Transform enemy in branch)
                {
                    if (enemy.GetComponent<MoveForward>())
                    {
                        enemy.GetComponent<MoveForward>().canMove = true;
                    }
                    else if (enemy.GetComponent<BackAndForth>())
                    {
                        enemy.GetComponent<BackAndForth>().canMove = true;
                    }
                }
            }
        }
    }
}
