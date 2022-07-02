using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAttack : EnemyAttackBaseClass
{
    public override void Start()
    {
        player = Player.Instance;
        attackDistance = 5;
        dmg = 2;
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
