using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovementInputController : MonoBehaviour
{
    public GameObject followTarget;
    public float speed = 1f;
    private Vector2 _move;
    private Vector2 _look;
    private const float _rotationPower = 0.3f;
    private const float _rotationLerp = 0.5f;

    public void OnMove(InputValue value) {
        _move = value.Get<Vector2>();
    }

    public void OnLook(InputValue value) {
        _look = value.Get<Vector2>();
    }

    private void Update()
    {
        followTarget.transform.rotation *= Quaternion.AngleAxis(_look.x * _rotationPower, Vector3.up);
        followTarget.transform.rotation *= Quaternion.AngleAxis(_look.y * _rotationPower, Vector3.left);

        Vector3 angles = followTarget.transform.localEulerAngles;
        angles.x = ClampRotation(angles.x);
        angles.z = 0;
        followTarget.transform.localEulerAngles = angles;
        transform.rotation = Quaternion.Euler(0, followTarget.transform.rotation.eulerAngles.y, 0);
        followTarget.transform.localEulerAngles = new Vector3(angles.x, 0, 0);

        float moveSpeed = speed / 100f;
        Vector3 moveDelta = (transform.forward * _move.y * moveSpeed) + (transform.right * _move.x * moveSpeed) + transform.up;
        transform.position += moveDelta;     
    }

    private float ClampRotation(float angle) {
        if (angle > 180 && angle < 340)
            return 340;
        else if(angle < 180 && angle > 40)
            return 40;
        return angle;
    }
}
