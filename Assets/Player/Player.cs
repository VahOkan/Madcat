using TMPro;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour, Interfaces.IDamageable
    {
        public static Player Instance;
        [SerializeField] private TextMeshProUGUI hpText;
        public int hp { get; set; }
        
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
    }
}
