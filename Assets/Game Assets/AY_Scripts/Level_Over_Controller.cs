using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Over_Controller : MonoBehaviour
{
    public string nextScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Ellen_Movement>() != null)
        {
            Ellen_Movement characterScript = collision.gameObject.GetComponentInChildren<Ellen_Movement>();
            PlayerPrefs.SetInt("PlayerHealth", characterScript.health);
            PlayerPrefs.SetInt("CurrentScore", characterScript.score);
            SceneManager.LoadScene(nextScene);
        }
    }
}