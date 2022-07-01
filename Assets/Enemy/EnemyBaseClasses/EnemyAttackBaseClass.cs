using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttackBaseClass : MonoBehaviour
{
    public Player player;
    public float attackDistance;
    public int dmg;
    void Update()
    {
        if (IsPlayerInDistance())
            PlayAttackAnimation();
    }
    public abstract void Start();
    public abstract bool IsPlayerInDistance();
    public abstract void PlayAttackAnimation();
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}
