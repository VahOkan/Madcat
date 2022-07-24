using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public static UnityAction FreezeGame;
    public static UnityAction UnFreezeGame;
    [SerializeField] private GameObject Settings;
    [SerializeField] private TMP_InputField sens;
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ContinueGame()
    {
        UnFreezeGame?.Invoke();
        Settings.SetActive(false);
        if(float.TryParse(sens.text, out float result))
        {
            Consts.RotationPower = result / 10;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !Settings.activeInHierarchy)
        {
            FreezeGame?.Invoke();
            Settings.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && Settings.activeInHierarchy)
            ContinueGame();
    }
}
