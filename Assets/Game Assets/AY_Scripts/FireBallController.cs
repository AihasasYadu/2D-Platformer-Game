using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    public int speed;
    public int animationLoopStartPositionY;
    public int animationLoopEndPositionY;
    private float x;
    private int time;
    private bool isTransitionComplete;
    private void Start()
    {
        x = gameObject.transform.localPosition.x;
        time = Mathf.Abs((animationLoopStartPositionY - animationLoopEndPositionY) / speed);
        ResetPosition();
    }
    private void Update()
    {
        if (gameObject.transform.localPosition.y == animationLoopStartPositionY)
        {
            FireBallTransition();
        }
        else if(gameObject.transform.localPosition.y == animationLoopEndPositionY)
        {
            ResetPosition();
        }
    }
    private void ResetPosition()
    {
        Vector2 pos = gameObject.transform.localPosition;
        pos.y = animationLoopStartPositionY;
        gameObject.transform.localPosition = pos;
    }
    private void FireBallTransition()
    {
        Debug.Log(gameObject.transform.localPosition);
        iTween.MoveTo(gameObject, iTween.Hash("y", animationLoopEndPositionY, 
            "time", time,
            "islocal", true,
            "easetype", iTween.EaseType.linear));
    }
}
