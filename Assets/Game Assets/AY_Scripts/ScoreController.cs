using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
<<<<<<< HEAD
    public Ellen_Movement characterScript;
=======
    //Public Variables
    public PlayerController characterScript;
    /*-------------------------------------------------------------*/

    //Private Variables
>>>>>>> d1094e4... Re-Modelled the whole lobby scene
    private TextMeshProUGUI scoreText;
    private int score = 0;

    private void Awake()
    {
        characterScript.score = PlayerPrefs.GetInt("CurrentScore");
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
