using System;
using UnityEngine;
using TMPro;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public TextMeshProUGUI ammoText;
    private GunBaseClass currentGun;

    private bool isFrozen;
    private void Start()
    {
        SettingsManager.FreezeGame += Freeze;
        SettingsManager.UnFreezeGame += UnFreeze;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        currentGun = GetComponentInChildren<GunBaseClass>();
    }
    private void OnDisable()
        {
            SettingsManager.FreezeGame -= Freeze;
            SettingsManager.UnFreezeGame -= UnFreeze;
        }
    private void Update()
    {
        if (isFrozen)
            return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
            currentGun.Shoot();

        if (Input.GetKeyDown(KeyCode.R))
            currentGun.Reload();
    }
    public void PickedUpAmmoBox()
    {
        AudioManager.Instance.PlaySound("Ammo");
        currentGun.AddAmmo();
    }
    void Freeze()
    {
        isFrozen = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    void UnFreeze()
    {
        isFrozen = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
