using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    int hpToAdd;
    private void Start()
    {
        hpToAdd = Random.Range(1, 10);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent(out PlayerHP player))
        {
            player.AddHP(hpToAdd);
            Destroy(gameObject);
        }
    }
}
