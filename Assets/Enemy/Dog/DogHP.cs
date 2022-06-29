using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogHP : EnemyHPBaseClass
{
    public override void Start()
    {
        health = 10;
        armor = 1.5f;
    }
}

