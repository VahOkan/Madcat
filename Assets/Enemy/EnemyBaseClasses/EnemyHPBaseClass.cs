using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class EnemyHPBaseClass : MonoBehaviour
{
    [SerializeField] GameObject dmgPopup;
    public int hp;
    public float armor;
    public abstract void Start();
    public void TakeDmg(int dmg)
    {
        hp -= Mathf.CeilToInt(dmg/armor);
        GameObject newPopup = Instantiate(dmgPopup, transform.position, Quaternion.identity);
        newPopup.GetComponent<TextMeshPro>().text = dmg.ToString();
        if (hp <= 0)
            Die();
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
