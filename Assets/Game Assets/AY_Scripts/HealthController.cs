using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthController : MonoBehaviour
{
    private TextMeshProUGUI healthText;
<<<<<<< HEAD
    public Ellen_Movement gameCharacter;
=======

    public PlayerController gameCharacter;
>>>>>>> d1094e4... Re-Modelled the whole lobby scene

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