using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score = 0;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void ScoreUpdate(int increment)
    {
        score += increment;
        RefreshGUI();
    }

    private void RefreshGUI()
    {
        scoreText.text = "Score : " + score;
    }
}
