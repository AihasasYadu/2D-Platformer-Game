using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private string keyPickSound = "KeyPick";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponentInChildren<PlayerController>() != null)
        {
            PlayerController characterScript = collision.gameObject.GetComponentInChildren<PlayerController>();
            characterScript.PickUp();
            FindObjectOfType<AudioManagerController>().Play(keyPickSound);
            Destroy(gameObject);
        }
    }
}
