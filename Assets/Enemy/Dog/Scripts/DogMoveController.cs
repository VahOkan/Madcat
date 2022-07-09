using Enemy.Base;
using Player;

namespace Enemy.Dog
{
    public class DogMoveController : BaseEnemyMoveController
    {
        public void Start()
        {
            playerHp = Player.PlayerHP.Instance;
            defaultSpeed = 3;
            attackSpeed = 6;
            viewDistance = 10;
        }

        protected override void Freeze()
        {
            agent.isStopped = true;
            isFrozen = true;
        }

        protected override void UnFreeze()
        {
            agent.isStopped = false;
            isFrozen = false;
        }
    }
}
