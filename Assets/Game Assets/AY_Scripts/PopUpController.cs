using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpController : MonoBehaviour
{
    public Button unclickedButton;
    private Image popUpImg;
    private void Awake()
    {
        popUpImg = GetComponent<Image>();
        unclickedButton.onClick.AddListener(SwitchButtons);
    }
    private void SwitchButtons()
    {
        popUpImg.gameObject.SetActive(false);
    }
}
