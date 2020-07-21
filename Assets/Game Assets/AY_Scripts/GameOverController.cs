using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public int gameOverOverlayDirection = 1;
    public int buttonOverlaySpeed;
    public Button restartButton;
    public Button lobbyButton;
    public bool playerDead;
    private Animator gameOverAnim;
    private bool positioned;
    private bool gameOverIMG_Positoned;
    private string gameOverSound = "GameOverSound";
    private string gameOverEntryAnim = "GameOverEntrance";

    private void Start()
    {
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
            gameOverAnim.Play(gameOverEntryAnim, -1, 0f);
            gameOverIMG_Positoned = !gameOverIMG_Positoned;
            AudioManagerController a = FindObjectOfType<AudioManagerController>();
            a.Play(gameOverSound);
            a.sounds[0].source.volume = 0;
            Destroy(AudioManagerController.Instance);
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
}
