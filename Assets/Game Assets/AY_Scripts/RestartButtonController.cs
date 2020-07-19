using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButtonController : MonoBehaviour
{
    private Button button;
    [HideInInspector] public bool buttonClicked;
    private void Awake()
    {
        buttonClicked = false;
        button = GetComponent<Button>();
        button.onClick.AddListener(delegate { buttonClicked = true; });
    }

    private void Update()
    {
        if(buttonClicked)
        {
            ReloadLevel();
        }
    }
    private void ReloadLevel()
    {
        PlayerPrefs.SetInt("PlayerHealth", 100);
        PlayerPrefs.SetInt("CurrentScore", 0);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
