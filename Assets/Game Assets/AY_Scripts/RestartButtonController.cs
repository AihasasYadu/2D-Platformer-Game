using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButtonController : MonoBehaviour
{
    private Button button;
    private string prefabHealth = "PlayerHealth";
    private string prefabScore = "CurrentScore";
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ReloadLevel);
    }
    private void ReloadLevel()
    {
        PlayerPrefs.SetInt(prefabHealth, 100);
        PlayerPrefs.SetInt(prefabScore, 0);
        Scene currentScene = SceneManager.GetActiveScene();
        SetThemeAudioVolume();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
    private void SetThemeAudioVolume()
    {
        if(AudioManagerController.Instance != null)
            FindObjectOfType<AudioManagerController>().sounds[0].source.volume = 0.5f;
    }
}
