using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    public bool asPattern;
    public Animation anim;
    public Vector2 targetPos;

    public int maxHp;
    public int damageOnCollision;
    public int damageOnBullet;
    public float fireRate;
    public float fireSpeed;

    public void SetTargetPos(Vector2 newTargetPos)
    {
        targetPos = newTargetPos;
    }
    
}