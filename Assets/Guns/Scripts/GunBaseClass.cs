using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class GunBaseClass : MonoBehaviour
{
    protected Camera mainCamera;
    protected TextMeshProUGUI ammoText;

    protected int dmg;
    protected int ammoLeft;
    protected int ammoInCurrentMag;
    protected static int ammoMagazineCanHold;
    private void OnEnable()
    {
        mainCamera = Camera.main;
        ammoText = GetComponentInParent<PlayerShoot>().ammoText;
    }
    protected abstract void Start();
    public abstract void Shoot();
    public void Reload()
    {
        if (ammoLeft + ammoInCurrentMag >= ammoMagazineCanHold)
        {
            ammoLeft -= ammoMagazineCanHold - ammoInCurrentMag;
            ammoInCurrentMag = ammoMagazineCanHold;
        }
        else
        {
            ammoInCurrentMag = ammoLeft + ammoInCurrentMag;
            ammoLeft = 0;
        }

        ammoText.text = "Ammo: " + ammoInCurrentMag + " / " + ammoLeft;
    }
    public abstract void AddAmmo();
}
