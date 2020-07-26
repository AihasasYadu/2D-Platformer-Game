using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFallingController : MonoBehaviour
{
    public GameObject[] slidingPlatforms;
    public float yPosition;
    public bool switchRigidBody2dOn;
    private int playerLayer = 8;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(playerLayer))
        {
            if(switchRigidBody2dOn)
            {
                for (int i = 0; i < slidingPlatforms.Length; i++)
                {
                    slidingPlatforms[i].AddComponent<Rigidbody2D>().freezeRotation = true;
                    slidingPlatforms[i].GetComponent<Rigidbody2D>().mass = 1000;
                    slidingPlatforms[i].GetComponent<Rigidbody2D>().gravityScale = 10;
                }
            }
            else
                StartPlatformsToFall();

            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    private void StartPlatformsToFall()
    {
        for (int i = 0; i < slidingPlatforms.Length; i++)
        {
            iTween.MoveTo(slidingPlatforms[i], iTween.Hash("y", yPosition, 
                "time", 1f, 
                "delay", (0.2+(i*0.2)), 
                "easetype", iTween.EaseType.easeInSine));
        }
    }
}
