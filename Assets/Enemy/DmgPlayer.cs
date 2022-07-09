using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgPlayer : MonoBehaviour
{
    
    [SerializeField] private EnemyAttackBaseClass parentObject;
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.transform.name);
        if (collision.transform.TryGetComponent(out PlayerHP player))
        {
            player.TakeDmg(parentObject.dmg);
        }
    }
}
