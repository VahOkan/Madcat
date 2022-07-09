using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttackBaseClass : MonoBehaviour
{
    public Player player;
    public float attackDistance;
    public int dmg;
    private void Update()
    {
        if (IsPlayerInDistance())
            PlayAttackAnimation();
    }
    public abstract void Start();
    protected abstract bool IsPlayerInDistance();
    protected abstract void PlayAttackAnimation();
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}
