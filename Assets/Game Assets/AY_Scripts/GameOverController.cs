using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public PlayerController gameCharacter;
    public int gameOverOverlayDirection = 1;
    public int buttonOverlaySpeed;
    public Button restartButton;
    public Button lobbyButton;
    public bool playerDead;
    private Image gameOver;
    private Animator gameOverAnim;
    private bool positioned;
    private bool gameOverIMG_Positoned;

    private void Awake()
    {
        restartButton.onClick.AddListener(ReloadLevel);
        lobbyButton.onClick.AddListener(LoadLobby);
    }
    private void Start()
    {
        gameOver = GetComponent<Image>();
        gameOverAnim = GetComponent<Animator>();
        positioned = false;
        gameOverIMG_Positoned = false;
    }

    private void Update()
    {
        if (playerDead && !positioned)
        {
            GameOverOverlay();
        }
    }

    public void GameOverOverlay()
    {
        if (!gameOverIMG_Positoned)
        {
            gameOverAnim.Play("GameOverEntrance", -1, 0f);
            Debug.Log("Positioned");
            gameOverIMG_Positoned = !gameOverIMG_Positoned;
        }
        RestartButtonTransition();
        LobbyButtonTransition();
    }

    private void RestartButtonTransition()
    {
        Vector2 pos = restartButton.transform.localPosition;
        pos.y += buttonOverlaySpeed * Time.deltaTime;
        if (pos.y > -70)
        {
            pos.y = -60;
        }
        restartButton.transform.localPosition = pos;
    }

    private void LobbyButtonTransition()
    {
        Vector2 pos = lobbyButton.transform.localPosition;
        pos.y += buttonOverlaySpeed * Time.deltaTime;
        if (pos.y > -125)
        {
            pos.y = -120;
            positioned = true;
        }
        lobbyButton.transform.localPosition = pos;
    }

    private void ReloadLevel()
    {
        PlayerPrefs.SetInt("PlayerHealth", 100);
        PlayerPrefs.SetInt("CurrentScore", 0);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
    private void LoadLobby()
    {
        SceneManager.LoadScene(0);
    }
}
