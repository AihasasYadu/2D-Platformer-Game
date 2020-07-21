using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LobbyButtonsController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [HideInInspector]
    public bool outOfCanvas;
    public bool isFroward;
    private Button button;
    private string quitButton = "Quit";
    private string mouseHoverAnimCondition = "MouseHover";
    private void Start()
    {
        outOfCanvas = true;
        isFroward = false;
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(OutOfCanvas);
    }
    private void Update()
    {
        if (!outOfCanvas)
        {
            Move();
        }
        if(button.transform.position.x > 2000)
        {
            gameObject.SetActive(false);
        }
    }
    private void OutOfCanvas()
    {
        if(gameObject.name != quitButton)
            outOfCanvas = false;
    }
    public void Move()
    {
        Vector2 pos = transform.position;
        pos.x += 1 * 1000 * Time.deltaTime;
        transform.position = pos;
    }
    public void OnPointerEnter(PointerEventData data)
    {
        GetComponent<Animator>().SetBool(mouseHoverAnimCondition, true);
    }
    public void OnPointerExit(PointerEventData data)
    {
        GetComponent<Animator>().SetBool(mouseHoverAnimCondition, false);
    }

}
