using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyHPBaseClass : MonoBehaviour
{
    public int health;
    public float armor;
    public abstract void Start();
    public void TakeDmg(int dmg)
    {
        health -= Mathf.CeilToInt(dmg/armor);
        if (health <= 0)
            Die();
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
