using System;
using UnityEngine;
using TMPro;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] TextMeshProUGUI ammoText;
    private bool isFrozen;
    int ammo;

    private int _dmg;
    private void Start()
    {
        SettingsManager.FreezeGame += Freeze;
        SettingsManager.UnFreezeGame += UnFreeze;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _dmg = 1;
        ammo = 10;
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
        
        if(PlayerShot() && ammo > 0)
        {
            ammo--;
            ammoText.text = "Ammo: " + ammo;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity))
                DamageHitEnemy(hit);
        }
    }
    private bool PlayerShot()
    {
        return Input.GetKeyDown(KeyCode.Mouse0);
    }
    private void DamageHitEnemy(RaycastHit hit)
    {
        if (hit.transform.TryGetComponent(out BaseEnemy hitEnemy))
            hitEnemy.TakeDmg(_dmg);
    }
    public void AddAmmo(int ammoToAdd)
    {
        ammo += ammoToAdd;
        ammoText.text = "Ammo: " + ammo;
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
