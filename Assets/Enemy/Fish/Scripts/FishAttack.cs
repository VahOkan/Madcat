using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAttack : EnemyAttackBaseClass
{
    public override void Start()
    {
        player = Player.Instance;
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
