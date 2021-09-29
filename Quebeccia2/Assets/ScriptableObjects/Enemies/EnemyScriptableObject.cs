using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    public bool asPattern;
    public Animation anim;
    public Vector2 targetPos;
    public float moveSpeed;

    public int maxHp;
    public int damageOnCollision;
    public int scoreIncrease;
    
    public bool canShoot;
    public GameObject bullet;
    public int damageOnBullet;
    public int fireRate;
    public float fireSpeed;

    public void SetTargetPos(Vector2 newTargetPos)
    {
        targetPos = newTargetPos;
    }
    
}