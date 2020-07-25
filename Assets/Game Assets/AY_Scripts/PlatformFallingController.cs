using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFallingController : MonoBehaviour
{
    public GameObject[] slidingPlatforms;
    private int playerLayer = 8;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(playerLayer))
        {
            StartPlatformsToFall();
        }
    }
    private void StartPlatformsToFall()
    {
        for (int i = 0; i < slidingPlatforms.Length; i++)
        {
            iTween.MoveTo(slidingPlatforms[i], iTween.Hash("y", -50, 
                "time", 1f, 
                "delay", (0.2+(i*0.2)), 
                "easetype", iTween.EaseType.easeInSine));
        }
    }
}
