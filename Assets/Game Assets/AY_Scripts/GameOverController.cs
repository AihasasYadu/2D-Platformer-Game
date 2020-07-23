using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public GameObject gameOverImg;
    public GameObject restartButton;
    public GameObject lobbyButton;
    public int gameOverTargetPosition;
    public int restartButtonTargetPosition;
    public int lobbyButtonTargetPosition;
    public void GameOverOverlay()
    {
        iTween.MoveTo(gameOverImg, iTween.Hash(
            "y", gameOverTargetPosition,
            "time", 1,
            "easetype", iTween.EaseType.easeOutBounce));

        iTween.MoveTo(restartButton, iTween.Hash(
            "y", restartButtonTargetPosition,
            "time", 1,
            "easetype", iTween.EaseType.easeOutBounce));

        iTween.MoveTo(lobbyButton, iTween.Hash(
            "y", lobbyButtonTargetPosition,
            "time", 1,
            "easetype", iTween.EaseType.easeOutBounce));
    }
}