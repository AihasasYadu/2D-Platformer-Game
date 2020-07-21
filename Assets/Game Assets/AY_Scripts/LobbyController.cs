using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button playButton;
    public Button levelSelectButton;
    public Button quitButton;
    public Image levelSelectorIMG;
    private string prefabHealth = "PlayerHealth";
    private string prefabScore = "CurrentScore";
    private string prefabLevel = "LastLevel";
    private string menuButtonClickSound = "MenuButtonClickSound";
    private void Awake()
    {
        playButton.onClick.AddListener(LoadLevel);
        levelSelectButton.onClick.AddListener(LevelSelector);
        quitButton.onClick.AddListener(QuitGame);
    }
    private void LoadLevel()
    {
        AudioManagerController a = FindObjectOfType<AudioManagerController>();
        a.Play(menuButtonClickSound);
        a.sounds[0].source.volume = 0;
        Destroy(AudioManagerController.Instance);
        PlayerPrefs.SetInt(prefabHealth, 100);
        PlayerPrefs.SetInt(prefabScore, 0);
        int level = PlayerPrefs.GetInt(prefabLevel,1);
        while(LevelManager.Instance.GetLevelStatus(("Level " + level)) == LevelStatus.Locked)
        {
            level -= 1;
        }
        SceneManager.LoadScene(level);
    }
    private void LevelSelector()
    {
        levelSelectorIMG.GetComponent<LevelSelectorController>().isButtonClicked = true;
        playButton.GetComponent<LobbyButtonsController>().outOfCanvas = false;
        quitButton.GetComponent<LobbyButtonsController>().outOfCanvas = false;
        FindObjectOfType<AudioManagerController>().Play(menuButtonClickSound);
    }

    private void QuitGame()
    {
        FindObjectOfType<AudioManagerController>().Play(menuButtonClickSound);
        Application.Quit();
    }
}