using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationKamikaze : MonoBehaviour
{
    public GameObject mainParent;
    public GameObject p1sideParent;
    public GameObject p2sideParent;
    
    public int phase = 0;

    public float speed = 0.1f;

    public List<GameObject> p1SideShips;
    public List<GameObject> p2SideShips;
    


    void Start()
    {
        transform.position = new Vector3(0, 10, 0);
        
        foreach(Transform child in p1sideParent.transform)
        {
            p1SideShips.Add(child.gameObject);
        }
        foreach(Transform child in p2sideParent.transform)
        {
            p2SideShips.Add(child.gameObject);
        }
    }
    
    
    void Update()
    {
        if (phase == 0)
        {
            float step =  speed * Time.deltaTime;
            mainParent.transform.position  = Vector3.MoveTowards(mainParent.transform.position, Vector3.zero, step);
            if (mainParent.transform.position == Vector3.zero)
            {
                phase++;
            }
        }
        else if (phase == 1)
        {
            
        }
    }
}
