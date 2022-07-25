using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMoveController : MonoBehaviour
{
    private bool isFrozen;

    #region AimVariables
    [SerializeField] private GameObject normalCameraObject;
    [SerializeField] private GameObject aimCameraObject;
    [SerializeField] private GameObject crossHair;
    float timeZoomingIn = 0;
    float elapsedTime = 0;
    #endregion

    #region MovementVariables
    public GameObject followTarget;
    private Vector2 _move;
    private Vector2 _look;
    #endregion

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
    private void Update()
    {
        if (isFrozen)
            return;

        followTarget.transform.rotation = RotateCinemachine(followTarget.transform.rotation);
        followTarget.transform.localEulerAngles = ClampRotation(followTarget.transform.localEulerAngles);
        MovePlayer();
        ResetCinemachine();

        #region Aim
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (!aimCameraObject.activeInHierarchy)
                AimCamera();

            if (crossHair.transform.localScale != new Vector3(5f, 5f, 5f))
                EnlargeCrosshair();
        }
        else
        {
            if (!normalCameraObject.activeInHierarchy)
                NormalCamera();

            if (crossHair.transform.localScale != new Vector3(2.5f, 2.5f, 2.5f))
                ShrinkCrosshair();
        }
        #endregion
    }
    void Freeze()
    {
        isFrozen = true;
    }
    void UnFreeze()
    {
        isFrozen = false;
    }

    #region MovementMethods
    public void OnMove(InputValue value) {
        _move = value.Get<Vector2>();
    }
    public void OnLook(InputValue value) {
        _look = value.Get<Vector2>();
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
                            (transform1.right * (_move.x * Consts.MoveSpeed));
        transform1.position += moveDelta * Time.deltaTime;
    }
    private void ResetCinemachine()
    {
        followTarget.transform.localEulerAngles = new Vector3(followTarget.transform.localEulerAngles.x, 0, 0);
    }
    #endregion

    #region AimMethods
    void EnlargeCrosshair()
    {
        elapsedTime += Time.deltaTime;
        float percentageCompleted = elapsedTime / 0.5f;
        crossHair.transform.localScale = Vector3.Lerp(Consts.PlayerMinScaleForZoomOut, new Vector3(5f, 5f, 5f), percentageCompleted);
        Consts.PlayerMaxScaleForZoomIn = crossHair.transform.localScale;
        if (percentageCompleted < 1) { timeZoomingIn += Time.deltaTime; }
    }
    void ShrinkCrosshair()
    {
        elapsedTime += Time.deltaTime;
        float percentageCompleted = elapsedTime / timeZoomingIn;
        crossHair.transform.localScale = Vector3.Lerp(Consts.PlayerMaxScaleForZoomIn, new Vector3(2.5f, 2.5f, 2.5f), percentageCompleted);
        Consts.PlayerMinScaleForZoomOut = crossHair.transform.localScale;
        if (percentageCompleted >= 1) { timeZoomingIn = 0; }
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
    #endregion
}
