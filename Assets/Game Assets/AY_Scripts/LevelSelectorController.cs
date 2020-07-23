using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorController : MonoBehaviour
{
    public Button levelSelectButton;
    public Button closeButton;
    private int imgNewScale = 1;
    private int imgOldScale = 0;
    private void Start()
    {
        levelSelectButton.onClick.AddListener(ScaleImageUp);
        closeButton.onClick.AddListener(ScaleImageToNormal);
    }
    private void ScaleImageUp()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("x", imgNewScale, "y", imgNewScale, "time", 1, "easetype", iTween.EaseType.easeOutBounce));
    }
    private void ScaleImageToNormal()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("x", imgOldScale, "y", imgOldScale, "time", 1, "easetype", iTween.EaseType.easeOutSine));
    }
}
