using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LobbyButtonsController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Hashtable hashTable = new Hashtable();
    private int buttonNewScale = 5;
    private int buttonOldScale = 4;
    private void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(PlayButtonClickSound);
    }
    private void PlayButtonClickSound()
    {
        AudioManagerController.Instance.Play(AudioTitles.ButtonClick);
    }
    private void ScaleButtonUp()
    {
        hashTable.Clear();
        hashTable.Add("x", buttonNewScale);
        hashTable.Add("y", buttonNewScale);
        hashTable.Add("time", 1);
        hashTable.Add("easetype", iTween.EaseType.easeOutBounce);
    }
    private void ScaleButtonBackToNormal()
    {
        hashTable.Clear();
        hashTable.Add("x", buttonOldScale);
        hashTable.Add("y", buttonOldScale);
        hashTable.Add("time", 1);
        hashTable.Add("easetype", iTween.EaseType.easeOutBounce);
    }

    public void OnPointerEnter(PointerEventData data)
    {
        ScaleButtonUp();
        iTween.ScaleTo(gameObject, hashTable);
    }
    public void OnPointerExit(PointerEventData data)
    {
        ScaleButtonBackToNormal();
        iTween.ScaleTo(gameObject, hashTable);
    }

}
