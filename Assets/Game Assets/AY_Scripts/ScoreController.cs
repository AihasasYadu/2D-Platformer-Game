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
    private int score;

    private void Start()
    {
        score = characterScript.score;
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
