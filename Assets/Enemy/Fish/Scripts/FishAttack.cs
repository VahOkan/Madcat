using Enemy.Base;
using Player;
using UnityEngine;

namespace Enemy.Fish
{
    public class FishAttack : BaseEnemyAttack
    {
        private void Start()
        {
            player = Player.Player.Instance;
            attackDistance = 7;
            dmg = 1;
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
