using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class DogAttack : EnemyAttackBaseClass
{
    public override void Start()
    {
        player = Player.PlayerHP.Instance;
        attackDistance = 5;
        dmg = 2;
    }
    protected override void PlayAttackAnimation()
    {

    }
    protected override bool IsPlayerInDistance()
    {
        return Vector3.Distance(transform.position, player.transform.position) < attackDistance ? true : false;
    }
    protected override void Freeze()
    {
        isFrozen = true;
    }
    protected override void UnFreeze()
    {
        isFrozen = false;
    }
}
