using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_Over_Controller : MonoBehaviour
{
    public Image levelFinished;
    public int overlaySpeed;
    private bool overlayPositioned;
    private void Start()
    {
        overlayPositioned = true;
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
        }
        levelFinished.transform.localPosition = pos;
    }
}