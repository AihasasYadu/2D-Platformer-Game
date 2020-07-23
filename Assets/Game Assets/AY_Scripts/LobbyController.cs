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
    private void Awake()
    {
        playButton.onClick.AddListener(LoadLevel);
        quitButton.onClick.AddListener(QuitGame);
        AudioManagerController.Instance.Play(AudioTitles.LobbyTheme);
    }
    private void LoadLevel()
    {
        AudioManagerController.Instance.Stop(AudioTitles.LobbyTheme);
        int level = PlayerPrefs.GetInt(prefabLevel,1);
        while(LevelManager.Instance.GetLevelStatus(("Level " + level)) == LevelStatus.Locked)
        {
            level -= 1;
        }
        SceneManager.LoadScene(level);
    }
    private void QuitGame()
    {
        Application.Quit();
    }
}