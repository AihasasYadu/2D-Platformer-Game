using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Ellen_Movement gameCharacter;
    public int gameOverTextDirection = 1;
    public int textOverlaySpeed;
    public Button restartButton;
    private TextMeshProUGUI gameOver;

    private void Awake()
    {
        restartButton.onClick.AddListener(ReloadLevel);
    }
    private void Start()
    {
        gameOver = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        //Debug.Log(gameCharacter.name);
        GameOverOverlay();
    }

    public void GameOverOverlay()
    {
        if (gameCharacter.anime.GetBool("Death") && !(gameOver.transform.position.x > 2000))
        {
            Vector2 pos = gameOver.transform.position;
            pos.x += gameOverTextDirection * textOverlaySpeed * Time.deltaTime;
            gameOver.transform.position = pos;
        }
        if (gameOver.transform.position.x > 2000)
        {
            /*SceneManager.LoadScene(SceneManager.GetActiveScene().name);*/
            restartButton.gameObject.SetActive(true);
        }
    }

    private void ReloadLevel()
    {
        PlayerPrefs.SetInt("PlayerHealth", 100);
        PlayerPrefs.SetInt("CurrentScore", 0);
        SceneManager.LoadScene(1);
    }
}
