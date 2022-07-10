public class FishMoveController : BaseEnemyMoveController
{
    public void Start()
    {
        playerHp = PlayerHP.Instance;
        defaultSpeed = 1;
        attackSpeed = 4;
        viewDistance = 8;
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
