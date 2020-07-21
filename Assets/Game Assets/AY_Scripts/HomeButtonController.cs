using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeButtonController : MonoBehaviour
{
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadLobby);
    }
    private void LoadLobby()
    {
        Destroy(AudioManagerController.Instance);
        SceneManager.LoadScene(0);
    }
}
