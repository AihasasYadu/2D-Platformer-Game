using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextSceneButtonController : MonoBehaviour
{
    public PlayerController characterScript;
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
        if (buttonClicked)
        {
            LoadNextLevel();
        }
    }
    private void LoadNextLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int nextSceneIndex = currentScene.buildIndex + 1;
        PlayerPrefs.SetInt("PlayerHealth", characterScript.health);
        PlayerPrefs.SetInt("CurrentScore", characterScript.score);
        SceneManager.LoadScene(nextSceneIndex);
    }
}
