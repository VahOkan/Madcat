namespace Interfaces
{
    public interface IDamageable
    {
        int hp { get; set; }
        void TakeDmg(int dmg);
    }
}