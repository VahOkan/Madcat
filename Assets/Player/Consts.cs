using UnityEngine;
public class Consts : MonoBehaviour //TODO - fuck consts?
{
    public static float MoveSpeed = 0.01f;
    public static float RotationPower = 0.3f;
    public static float RotationLerp = 0.5f;
    public static float EnemyStartCheckingIfStuck = 0;
    public static float EnemyCheckingIfStuckRepeatRate = 1;
    public static float WalkRadius = 8;
    public static float StuckSpeed = 0.5f;
    public static float Acceleration = 3;
    public static Vector3 PlayerMaxScaleForZoomIn = new Vector3(5, 5, 5);
    public static Vector3 PlayerMinScaleForZoomOut = new Vector3(2.5f, 2.5f, 2.5f);
}
