using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject SettingsPanel;
    [SerializeField] private GameObject StartPanel;
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {
        StartPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        SettingsPanel.SetActive(false);
        StartPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
