using UnityEngine;

public abstract class EnemyAttackBaseClass : MonoBehaviour
{
    public PlayerHP player;
    public float attackDistance;
    public int dmg;
    protected bool isFrozen;
    private void Update()
    {
        if (isFrozen)
            return;

        if (IsPlayerInDistance())
            PlayAttackAnimation();
    }
    public abstract void Start();
    protected abstract bool IsPlayerInDistance();
    protected abstract void PlayAttackAnimation();
    protected abstract void Freeze();
    protected abstract void UnFreeze();
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}
