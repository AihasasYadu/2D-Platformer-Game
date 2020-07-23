using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    public string levelName;
    public Image popUpLevelLocked;
    private string prefabHealth = "PlayerHealth";
    private string prefabScore = "CurrentScore";
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadCheck);
    }
    private void LoadCheck()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(levelName);
        switch(levelStatus)
        {
            case LevelStatus.Locked:
                {
                    AudioManagerController.Instance.Play(AudioTitles.PopUpError);
                    popUpLevelLocked.gameObject.SetActive(true);
                    break;
                }
            case LevelStatus.Unlocked:
                LoadLevel();
                break;
            case LevelStatus.Completed:
                LoadLevel();
                break;
        }
        
    }

    private void LoadLevel()
    {
        PlayerPrefs.SetInt(prefabHealth, 100);
        PlayerPrefs.SetInt(prefabScore, 0);
        AudioManagerController.Instance.Stop(AudioTitles.LobbyTheme);
        SceneManager.LoadScene(levelName);
    }
}
