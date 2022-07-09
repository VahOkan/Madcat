using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Player
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        private bool isFrozen;

        private int _dmg;
        private void Start()
        {
            SettingsManager.FreezeGame += Freeze;
            SettingsManager.UnFreezeGame += UnFreeze;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            _dmg = 1;
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
            
            if(PlayerShot())
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit, Mathf.Infinity))
                    DamageHitEnemy(hit);
            }
        }
        private static bool PlayerShot()
        {
            return Input.GetKeyDown(KeyCode.Mouse0);
        }
        private void DamageHitEnemy(RaycastHit hit)
        {
            if (hit.transform.TryGetComponent(out Interfaces.IDamageable hitEnemy))
                hitEnemy.TakeDmg(_dmg);
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
}
