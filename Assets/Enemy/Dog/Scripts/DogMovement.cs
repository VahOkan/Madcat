using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogMovement : EnemyMoveBaseClass
{
    public void Start()
    {
        player = Player.Instance;
        defaultSpeed = 3;
        attackSpeed = 6;
        viewDistance = 10;
    }
}
