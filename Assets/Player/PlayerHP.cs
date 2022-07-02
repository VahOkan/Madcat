using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hpText;
    int hp;
    private void Start()
    {
        hp = 100;
    }
    public void TakeDmg(int dmg)
    {
        hp -= dmg;
        hpText.text = "HP: " + hp.ToString();
    }
}
