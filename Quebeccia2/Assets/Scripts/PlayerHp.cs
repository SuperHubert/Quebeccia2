using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    public int startingHp = 6;
    public int currentHp;
    public bool canTakeDamage = true;
    
    void Start()
    {
        currentHp = startingHp;
    }
}
