using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTextController : MonoBehaviour
{
    private TextMeshProUGUI levelText;
    private void Start()
    {
        levelText = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        RefreshGUI();
    }
    private void RefreshGUI()
    {
        levelText.text = "Level : " + SceneManager.GetActiveScene().buildIndex;
    }
}
