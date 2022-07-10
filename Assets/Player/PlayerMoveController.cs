using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMoveController : MonoBehaviour
{
    private bool isFrozen;
    public GameObject followTarget;
    private Vector2 _move;
    private Vector2 _look;

    private void Start()
    {
        SettingsManager.FreezeGame += Freeze;
        SettingsManager.UnFreezeGame += UnFreeze;
    }

    private void OnDisable()
    {
        SettingsManager.FreezeGame -= Freeze;
        SettingsManager.UnFreezeGame -= UnFreeze;
    }

    public void OnMove(InputValue value) {
        _move = value.Get<Vector2>();
    }
    public void OnLook(InputValue value) {
        _look = value.Get<Vector2>();
    }
    private void Update()
    {
        if (isFrozen)
        {
            transform.position += transform.up;
            return;
        }

        followTarget.transform.rotation = RotateCinemachine(followTarget.transform.rotation);
        followTarget.transform.localEulerAngles = ClampRotation(followTarget.transform.localEulerAngles);
        MovePlayer();
        ResetCinemachine();
    }
    private Quaternion RotateCinemachine(Quaternion followTargetRotation)
    {
        followTargetRotation *= Quaternion.AngleAxis(_look.x * Consts.RotationPower, Vector3.up);
        followTargetRotation *= Quaternion.AngleAxis(_look.y * Consts.RotationPower, Vector3.left);
        return followTargetRotation;
    }
    private Vector3 ClampRotation(Vector3 angles)
    {
        angles.x = angles.x switch
        {
            > 180 and < 340 => 340,
            < 180 and > 40 => 40,
            _ => angles.x
        };
        angles.z = 0;
        return angles;
    }
    private void MovePlayer()
    {
        Transform transform1;
        (transform1 = transform).rotation = Quaternion.Euler(0, followTarget.transform.rotation.eulerAngles.y, 0);
        Vector3 moveDelta = (transform1.forward * (_move.y * Consts.MoveSpeed)) + 
                            (transform1.right * (_move.x * Consts.MoveSpeed)) + transform1.up;
        transform1.position += moveDelta; 
    }
    private void ResetCinemachine()
    {
        followTarget.transform.localEulerAngles = new Vector3(followTarget.transform.localEulerAngles.x, 0, 0);
    }

    void Freeze()
    {
        isFrozen = true;
    }

    void UnFreeze()
    {
        isFrozen = false;
    }
}
