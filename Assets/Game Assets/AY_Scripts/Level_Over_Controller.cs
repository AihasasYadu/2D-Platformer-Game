using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_Over_Controller : MonoBehaviour
{
    public Image levelFinished;
    public Image levelCompleteGIF;
    public int overlaySpeed;
    private bool overlayPositioned;
    private string levelCompleteAnimParameter = "isLevelCompleted";
    private string prefabLevel = "LastLevel";
    private string levelCompleteSound = "LevelCompleteSound";
    private void Start()
    {
        overlayPositioned = true;
        levelCompleteGIF.GetComponent<Animator>().SetBool(levelCompleteAnimParameter, false);
    }
    private void Update()
    {
        if(!overlayPositioned)
        {
            LevelCompleteOverlayTransition();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController characterScript = collision.gameObject.GetComponentInChildren<PlayerController>();
            characterScript.freeze = true;
            LevelManager.Instance.MarkCurrentLevelComplete();
            overlayPositioned = false;
        }
    }
    private void LevelCompleteOverlayTransition()
    {
        Vector2 pos = levelFinished.transform.localPosition;
        pos.x += overlaySpeed * Time.deltaTime;
        if(pos.x > -5)
        {
            pos.x = 0;
            overlayPositioned = true;
            levelCompleteGIF.GetComponent<Animator>().SetBool(levelCompleteAnimParameter, true);
            AudioManagerController a = FindObjectOfType<AudioManagerController>();
            a.sounds[0].source.volume = 0;
            a.Play(levelCompleteSound);
            PlayerPrefs.SetInt(prefabLevel, SceneManager.GetActiveScene().buildIndex + 1);
        }
        levelFinished.transform.localPosition = pos;
    }
}