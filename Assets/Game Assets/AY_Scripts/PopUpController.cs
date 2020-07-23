using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpController : MonoBehaviour
{
    public Button closeButton;
    private void Awake()
    {
        closeButton.onClick.AddListener(DisablePopUp);
    }
    private void DisablePopUp()
    {
        this.gameObject.SetActive(false);
    }
}
