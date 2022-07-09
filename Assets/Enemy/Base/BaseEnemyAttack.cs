using Player;
using UnityEngine;

namespace Enemy.Base
{
    public abstract class BaseEnemyAttack : MonoBehaviour
    {
        public Player.Player player;
        public float attackDistance;
        public int dmg;
    
        private void Update()
        {
            if (IsPlayerInDistance())
                PlayAttackAnimation();
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackDistance);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Interfaces.IDamageable hitPlayer))
            {
                hitPlayer.TakeDmg(dmg);
            }
        }
        public abstract bool IsPlayerInDistance();
        public abstract void PlayAttackAnimation();

    }
}
