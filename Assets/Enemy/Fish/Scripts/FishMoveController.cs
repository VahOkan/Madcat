using Enemy.Base;
using Player;

namespace Enemy.Fish
{
    public class FishMoveController : BaseEnemyMoveController
    {
        public void Start()
        {
            player = Player.Player.Instance;
            defaultSpeed = 1;
            attackSpeed = 4;
            viewDistance = 8;
        }
    }
}
