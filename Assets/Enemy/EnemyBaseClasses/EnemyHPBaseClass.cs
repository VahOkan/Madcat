using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyHPBaseClass : MonoBehaviour
{
    public int hp;
    public float armor;
    public abstract void Start();
    public void TakeDmg(int dmg)
    {
        hp -= Mathf.CeilToInt(dmg/armor);
        if (hp <= 0)
            Die();
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
