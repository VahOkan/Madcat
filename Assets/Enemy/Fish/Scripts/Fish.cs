using Enemy.Base;
using Player;

namespace Enemy.Fish
{
    public class Fish : BaseEnemy, Interfaces.IDamageable
    {
        private void Start()
        {
            hp = 6;
            armor = 1;
        }
    }
}
