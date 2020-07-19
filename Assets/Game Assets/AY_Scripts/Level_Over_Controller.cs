using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Over_Controller : MonoBehaviour
{
    public string nextScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController characterScript = collision.gameObject.GetComponentInChildren<PlayerController>();
            PlayerPrefs.SetInt("PlayerHealth", characterScript.health);
            PlayerPrefs.SetInt("CurrentScore", characterScript.score);
            SceneManager.LoadScene(nextScene);
        }
    }
}