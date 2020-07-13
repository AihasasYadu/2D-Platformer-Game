using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    private void Awake()
    {
        button1.onClick.AddListener(LoadLevel);
        button2.onClick.AddListener(LoadLevel);
        button3.onClick.AddListener(LoadLevel);
    }

    private void LoadLevel()
    {
        PlayerPrefs.SetInt("PlayerHealth", 100);
        PlayerPrefs.SetInt("CurrentScore", 0);
        SceneManager.LoadScene(1);
    }
}
