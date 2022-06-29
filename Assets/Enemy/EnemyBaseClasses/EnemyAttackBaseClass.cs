using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttackBaseClass : MonoBehaviour
{
    public Player player;
    public float attackDistance;
    void Update()
    {
        if (IsPlayerInDistance())
            Attack();
    }
    public abstract void Start();
    public abstract bool IsPlayerInDistance();
    public abstract void Attack();
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}
