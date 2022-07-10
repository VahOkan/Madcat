using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    int ammoAmount;
    private void Start()
    {
        ammoAmount = Random.Range(0, 10);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent(out PlayerShoot player))
        {
            player.AddAmmo(ammoAmount);
            Destroy(gameObject);
        }
    }
}
