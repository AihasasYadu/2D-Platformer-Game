using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    public string levelName;
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
                Debug.Log("Level Locked");
                break;
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
        PlayerPrefs.SetInt("PlayerHealth", 100);
        PlayerPrefs.SetInt("CurrentScore", 0);
        SceneManager.LoadScene(levelName);
    }
}
