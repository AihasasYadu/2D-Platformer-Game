using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Ellen_Movement gameCharacter;
    public int gameOverTextDirection = 1;
    public int textOverlaySpeed;
    private TextMeshProUGUI gameOver;

    private void Start()
    {
        //gameCharacter = GetComponentInParent<Ellen_Movement>();
        gameOver = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        //Debug.Log(gameCharacter.name);
        if (gameCharacter.anime.GetBool("Death"))
        {
            Vector2 pos = gameOver.transform.position;
            pos.x += gameOverTextDirection * textOverlaySpeed * Time.deltaTime;
            gameOver.transform.position = pos;
        }
        if(gameOver.transform.position.x > 800)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
