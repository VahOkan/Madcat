using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Camera myCam;
    int dmg;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        dmg = 1;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray ,out hit, Mathf.Infinity)
            && hit.transform.TryGetComponent(out EnemyHPBaseClass enemy)) 
            {
                enemy.TakeDmg(dmg);
            }
        }
    }
}
