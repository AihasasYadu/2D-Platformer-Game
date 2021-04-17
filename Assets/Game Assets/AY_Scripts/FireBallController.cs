using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    public int speed;
    public int animationLoopStartPositionY;
    public int animationLoopEndPositionY;
    private int time;
    private void Start()
    {
        time = Mathf.Abs((animationLoopStartPositionY - animationLoopEndPositionY) / speed);
        ResetPosition();
        FireBallTransition();
    }
    private void ResetPosition()
    {
        Vector2 pos = gameObject.transform.localPosition;
        pos.y = animationLoopStartPositionY;
        gameObject.transform.localPosition = pos;
    }
    private void FireBallTransition()
    {
        iTween.MoveTo(gameObject, iTween.Hash("y", animationLoopEndPositionY, 
            "time", time,
            "islocal", true,
            "looptype", iTween.LoopType.loop,
            "easetype", iTween.EaseType.linear));
    }
}
