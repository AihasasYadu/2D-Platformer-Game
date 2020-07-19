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
    private void Awake()
    {
        playButton.onClick.AddListener(LoadLevel);
        levelSelectButton.onClick.AddListener(LevelSelector);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void LoadLevel()
    {
        int level = 1;
        PlayerPrefs.SetInt("PlayerHealth", 100);
        PlayerPrefs.SetInt("CurrentScore", 0);
        level = PlayerPrefs.GetInt("LastLevel");
        SceneManager.LoadScene(level);
    }
    private void LevelSelector()
    {
        levelSelectorIMG.GetComponent<LevelSelectorController>().isButtonClicked = true;
        playButton.GetComponent<LobbyButtonsController>().outOfCanvas = false;
        quitButton.GetComponent<LobbyButtonsController>().outOfCanvas = false;
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}