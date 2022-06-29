using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FishMovement : EnemyMoveBaseClass
{
    public void Start()
    {
        player = Player.Instance;
        defaultSpeed = 1;
        attackSpeed = 4;
        viewDistance = 8;
    }
}
