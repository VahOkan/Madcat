using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishHP : EnemyHPBaseClass
{
    public override void Start()
    {
        health = 6;
        armor = 1;
    }
}
