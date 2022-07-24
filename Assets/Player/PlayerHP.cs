using TMPro;
using UnityEngine;
public class PlayerHP : MonoBehaviour
{
    public static PlayerHP Instance;
    [SerializeField] private TextMeshProUGUI hpText;
    int hp;
    
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        hp = 100;
    }
    public void TakeDmg(int dmg)
    {
        hp -= dmg;
        hpText.text = "HP: " + hp.ToString();
    }
    public void AddHP(int hpToAdd)
    {
        AudioManager.Instance.PlaySound("HP");
        hp += hpToAdd;
        if (hp > 100)
            hp = 100;
        hpText.text = "HP: " + hp.ToString();
    }
}
