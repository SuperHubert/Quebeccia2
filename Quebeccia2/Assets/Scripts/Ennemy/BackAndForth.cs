using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    public float speed = 0.1f;

    public List<Vector3> listOfPositions = new List<Vector3>();
    
    public int phase = 0;
    public Vector3 targetPos;
    public bool canMove = false;
    
    void Start()
    {
        DebugLog();
        targetPos = listOfPositions[0];
    }
    
    void Update()
    {
        if (canMove)
        {
            if (transform.position == targetPos)
            {
                ChangeTarget();
            }
        
            Move();
        }
        
    }

    void Move()
    {
        float step =  speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
    }

    void ChangeTarget()
    {
        phase++;
        if (phase == listOfPositions.Count)
        {
            phase = 0;
        }

        targetPos = listOfPositions[phase];
    }

    void DebugLog()
    {
        Debug.Log(listOfPositions[0]);
        
    }
}
