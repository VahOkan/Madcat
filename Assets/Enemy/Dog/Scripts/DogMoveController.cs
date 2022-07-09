using Enemy.Base;
using Player;

namespace Enemy.Dog
{
    public class DogMoveController : BaseEnemyMoveController
    {
        public void Start()
        {
            player = Player.Player.Instance;
            defaultSpeed = 3;
            attackSpeed = 6;
            viewDistance = 10;
        }
    }
}
