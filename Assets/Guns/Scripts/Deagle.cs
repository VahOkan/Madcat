using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deagle : GunBaseClass
{
    protected override void Start()
    {
        dmg = 3;
        ammoLeft = 24;
        ammoInCurrentMag = 6;
        ammoMagazineCanHold = 6;
    }
    public override void Shoot()
    {
        if (ammoInCurrentMag > 0)
        {
            ammoInCurrentMag--;
            ammoText.text = "Ammo: " + ammoInCurrentMag + " / " + ammoLeft;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity))
                DamageHitEnemy(hit);
        }
        else 
        {
            //TODO - play some sound
        }
    }
    public override void AddAmmo()
    {
        ammoLeft += Random.Range(1, 10);
        ammoText.text = "Ammo: " + ammoInCurrentMag + " / " + ammoLeft;
    }
    private void DamageHitEnemy(RaycastHit hit)
    {
        if (hit.transform.TryGetComponent(out BaseEnemy hitEnemy))
            hitEnemy.TakeDmg(dmg);
    }
}
