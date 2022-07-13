using System;
using UnityEngine;
using TMPro;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject normalCameraObject;
    [SerializeField] private GameObject aimCameraObject;
    [SerializeField] private GameObject crossHair;
    [SerializeField] TextMeshProUGUI ammoText;

    float timeInCameraTransition = 0;
    Vector3 lastScaleForZoomIn = new Vector3(5,5,5);
    Vector3 lastScaleForZoomOut = new Vector3(2.5f,2.5f,2.5f);

    private bool isFrozen;
    int ammo;
    float elapsedTime = 0;

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
        
        if(Input.GetKeyDown(KeyCode.Mouse0) && ammo > 0) //if left click is pressed down and we have ammo
            Shoot();

        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (!aimCameraObject.activeInHierarchy) 
                AimCamera();

            EnlargeCrosshair();
        }
        else
        {
            if (!normalCameraObject.activeInHierarchy) 
                NormalCamera();

            ShrinkCrosshair();
        }
    }
    void EnlargeCrosshair()
    {
        elapsedTime += Time.deltaTime;
        float percentageCompleted = elapsedTime / 0.5f;
        crossHair.transform.localScale = Vector3.Lerp(lastScaleForZoomOut, new Vector3(5f, 5f, 5f), percentageCompleted);
        lastScaleForZoomIn = crossHair.transform.localScale;
        if (percentageCompleted < 1) { timeInCameraTransition += Time.deltaTime; }
    }
    void ShrinkCrosshair()
    {
        elapsedTime += Time.deltaTime;
        float percentageCompleted = elapsedTime / timeInCameraTransition;
        crossHair.transform.localScale = Vector3.Lerp(lastScaleForZoomIn, new Vector3(2.5f, 2.5f, 2.5f), percentageCompleted);
        lastScaleForZoomOut = crossHair.transform.localScale;
        if (percentageCompleted >= 1) { timeInCameraTransition = 0; }
    }
    void Shoot()
    {
        ammo--;
        ammoText.text = "Ammo: " + ammo;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, Mathf.Infinity))
            DamageHitEnemy(hit);
    }
    void AimCamera()
    {
        elapsedTime = 0;
        normalCameraObject.SetActive(false);
        aimCameraObject.SetActive(true);
    }
    void NormalCamera()
    {
        elapsedTime = 0;
        aimCameraObject.SetActive(false);
        normalCameraObject.SetActive(true);
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
