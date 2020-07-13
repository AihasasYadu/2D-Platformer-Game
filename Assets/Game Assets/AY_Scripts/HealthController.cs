using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthController : MonoBehaviour
{
    private TextMeshProUGUI healthText;
    public Ellen_Movement gameCharacter;

    private void Awake()
    {
        gameCharacter.health = PlayerPrefs.GetInt("PlayerHealth");
    }
    private void Start()
    {
        /*gameCharacter = GetComponent<Ellen_Movement>();*/
        healthText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        RefreshGUI();
    }

    private void RefreshGUI()
    {
        //gameCharacter = GetComponent<Ellen_Movement>().health;
        healthText.text = "Health : " + gameCharacter.health;
    }
}