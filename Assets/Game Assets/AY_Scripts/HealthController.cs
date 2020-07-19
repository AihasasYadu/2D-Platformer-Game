using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthController : MonoBehaviour
{
    private TextMeshProUGUI healthText;
    public PlayerController gameCharacter;

    private void Awake()
    {
        gameCharacter.health = PlayerPrefs.GetInt("PlayerHealth");
    }
    private void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        RefreshGUI();
    }

    private void RefreshGUI()
    {
        healthText.text = "Health : " + gameCharacter.health;
    }
}