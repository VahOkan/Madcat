using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public static UnityAction FreezeGame;
    public static UnityAction UnFreezeGame;
    [SerializeField] private GameObject Settings;
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ContinueGame()
    {
        UnFreezeGame?.Invoke();
        Settings.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FreezeGame?.Invoke();
            Settings.SetActive(true);
        }
    }
}
