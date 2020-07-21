using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextSceneButtonController : MonoBehaviour
{
    public PlayerController characterScript;
    private Button button;
    private string prefabHealth = "PlayerHealth";
    private string prefabScore = "CurrentScore";
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
        PlayerPrefs.SetInt(prefabHealth, characterScript.health);
        PlayerPrefs.SetInt(prefabScore, characterScript.score);
        FindObjectOfType<AudioManagerController>().sounds[0].source.volume = 0.5f;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
