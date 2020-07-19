using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeButtonController : MonoBehaviour
{
    private Button button;
    [HideInInspector] public bool buttonClicked;
    private void Awake()
    {
        buttonClicked = false;
        button = GetComponent<Button>();
        button.onClick.AddListener(delegate { buttonClicked = true; });
    }

    private void Update()
    {
        if (buttonClicked)
        {
            LoadLobby();
        }
    }
    private void LoadLobby()
    {
        SceneManager.LoadScene(0);
    }
}
