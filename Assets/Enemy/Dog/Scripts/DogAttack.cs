using Enemy.Base;
using Player;
using UnityEngine;

namespace Enemy.Dog
{
    public class DogAttack : BaseEnemyAttack
    {
        private void Start()
        {
            player = Player.Player.Instance;
            attackDistance = 5;
            dmg = 2;
        }
        public override void PlayAttackAnimation()
        {

        }
        public override bool IsPlayerInDistance()
        {
            if (Vector3.Distance(transform.position, player.transform.position) < attackDistance)
                return true;
            else
                return false;
        }
    }
}
