using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent(out PlayerShoot player))
        {
            player.PickedUpAmmoBox();
            Destroy(gameObject);
        }
    }
}
