using Enemy.Base;
using Player;

namespace Enemy.Dog
{
    public class Dog : BaseEnemy, Interfaces.IDamageable
    {
        private void Start()
        {
            hp = 10;
            armor = 1.5f;
        }
    }
}

