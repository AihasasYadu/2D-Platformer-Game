using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSliderController : MonoBehaviour
{
    public GameObject[] slidingPlatforms;
    private int playerLayer = 8;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer.Equals(playerLayer))
        {
            RotatePlatforms();
        }
    }
    private void RotatePlatforms()
    {
        for(int i = 0; i < slidingPlatforms.Length; i++)
        {
            iTween.RotateTo(slidingPlatforms[i], iTween.Hash("z", -25, "time", 1.5f));
        }
    }
}
