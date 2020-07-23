using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_Over_Controller : MonoBehaviour
{
    public Animator anim;
    public RectTransform uGuiElement;
    public Vector2 targetPosition;
    private string levelCompleteAnimParameter = "isLevelCompleted";
    private void Start()
    {
        anim.SetBool(levelCompleteAnimParameter, false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController characterScript = collision.gameObject.GetComponentInChildren<PlayerController>();
            characterScript.freeze = true;
            characterScript.nextLevelReached = true;
            LevelManager.Instance.MarkCurrentLevelComplete();
            AudioManagerController.Instance.Stop(AudioTitles.SceneTheme);
            AudioManagerController.Instance.Play(AudioTitles.LevelComplete);
            LevelCompleteOverlayTransition();
        }
    }
    private void LevelCompleteOverlayTransition()
    {
        iTween.ValueTo(uGuiElement.gameObject, iTween.Hash(
         "from", uGuiElement.anchoredPosition,
         "to", targetPosition,
         "time", 1,
         "onupdatetarget", gameObject,
         "onupdate", "MoveGuiElement",
         "easetype", iTween.EaseType.easeOutCirc));

         anim.SetBool(levelCompleteAnimParameter, true);
    }
    public void MoveGuiElement(Vector2 position)
    {
        uGuiElement.anchoredPosition = position;
    }
}