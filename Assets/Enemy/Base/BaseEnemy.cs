using UnityEngine;
using TMPro;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] GameObject dmgPopup;
    public int hp { get; set; }
    public float armor;
    
    public void TakeDmg(int dmg)
    {
        hp -= Mathf.CeilToInt(dmg/armor);
        GameObject newPopup = Instantiate(dmgPopup, transform.position, Quaternion.identity);
        newPopup.GetComponent<TextMeshPro>().text = dmg.ToString();
        if (hp <= 0)
            Die();
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}