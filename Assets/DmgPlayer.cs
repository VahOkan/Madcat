using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgPlayer : MonoBehaviour
{
    [SerializeField] GameObject parentObject;
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.transform.name);
        if (collision.transform.TryGetComponent(out PlayerHP player))
        {
            player.TakeDmg(parentObject.GetComponent<EnemyAttackBaseClass>().dmg);
        }
    }
}
