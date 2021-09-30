using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixteV2 : MonoBehaviour
{
    public GameObject mainParent;
    public float mainSpeed = 1;
    public float timeSpent = 0;
    private bool canActivate = false;
    
    void Start()
    {
        mainParent = this.gameObject;
        mainParent.transform.position = Vector3.up * 10;
    }
    
    void Update()
    {
        if (mainParent.transform.position == Vector3.zero)
        {
            if (canActivate)
            {
                canActivate = false;
                StartCoroutine(WaitNextPhase());
            }
            
        }
        else
        {
            float step =  mainSpeed * Time.deltaTime;
            mainParent.transform.position = Vector3.MoveTowards(mainParent.transform.position, Vector3.zero, step);
        }
    }

    void ActivateUnits(float unitOrder)
    {
        foreach (Transform branch in mainParent.transform)
        {
            foreach (Transform enemy in branch)
            {
                if (enemy.GetComponent<Enemy>().timeUntilActive == unitOrder)
                {
                    if (enemy.GetComponent<MoveForward>())
                    {
                        enemy.GetComponent<MoveForward>().canMove = true;
                    }
                    else if (enemy.GetComponent<BackAndForth>())
                    {
                        enemy.GetComponent<BackAndForth>().canMove = true;
                    }
                    
                    if (enemy.GetComponent<Shooter>())
                    {
                        enemy.GetComponent<Shooter>().canShoot = true;
                    }
                }
                
            }
        }
    }

    IEnumerator WaitNextPhase()
    {
        yield return new WaitForSeconds(0.1f);
        timeSpent += 0.1f;
        ActivateUnits(timeSpent);
        canActivate = true;

    }
}
