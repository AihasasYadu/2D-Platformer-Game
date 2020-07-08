using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Over_Controller : MonoBehaviour
{
    public string nextScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided With:" + collision.gameObject.name);
        if (collision.gameObject.GetComponent<Ellen_Movement>() != null)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}