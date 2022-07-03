using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Player
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;

        private int _dmg;
        private void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            _dmg = 1;
        }
        private void Update()
        {
            if(PlayerShot())
            {
                try 
                {
                    RaycastHit hit = GetRayCastHit();
                    if (IsEnemyHit(hit))
                        DamageEnemy(hit);    
                }
                catch(NullReferenceException)
                {
                    // TODO: add a black point in environment 
                }
            }
        }
        private static bool PlayerShot()
        {
            return Input.GetKeyDown(KeyCode.Mouse0);
        }
        private static bool IsEnemyHit(RaycastHit hit)
        {
            return hit.transform.gameObject.CompareTag(Enemy.Consts.EnemyTag);  
        }
        private RaycastHit GetRayCastHit()
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity);
            return hit;
        }
        private void DamageEnemy(RaycastHit hit)
        {
            if(hit.transform.TryGetComponent(out Interfaces.IDamageable hitEnemy))
                hitEnemy.TakeDmg(_dmg);
        }
    }
}
