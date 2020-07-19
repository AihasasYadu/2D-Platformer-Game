using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorController : MonoBehaviour
{
    public int levelSelectorSpeed;

    [HideInInspector]
    public bool isButtonClicked;
    private Image levelSelector;
    private Vector2 pos;

    private void Start()
    {
        levelSelector = gameObject.GetComponent<Image>();
        pos = levelSelector.rectTransform.localPosition;
    }
    void Update()
    {
        if(!isInCenter() && isButtonClicked)
        Move();
    }
    private void Move()
    {
        pos.x += 1 * levelSelectorSpeed * Time.deltaTime;
        levelSelector.rectTransform.localPosition = pos;
    }
    private bool isInCenter()
    {
        bool returnedValue = false;
        if(levelSelector.rectTransform.localPosition.x > -5)
        {
            pos.x = 0;
            levelSelector.rectTransform.localPosition = pos;
            returnedValue = true;
        }
        return returnedValue;
    }
}
