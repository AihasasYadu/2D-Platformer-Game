using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    //Public Variables
    public PlayerController characterScript;
    /*-------------------------------------------------------------*/

    //Private Variables
    private TextMeshProUGUI scoreText;
    private int score = 0;
    private string prefabScore = "CurrentScore";

    private void Awake()
    {
        characterScript.score = PlayerPrefs.GetInt(prefabScore);
        score = characterScript.score;
    }
    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = "Score : " + score;
    }

    public void ScoreUpdate(int increment)
    {
        score += increment;
        characterScript.score = score;
        RefreshGUI();
    }

    private void RefreshGUI()
    {
        scoreText.text = "Score : " + score;
    }
}
