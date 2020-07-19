using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
<<<<<<< HEAD
    private void OnCollisionEnter2D(Collision2D collision)
=======

    private void OnTriggerEnter2D(Collider2D collision)
>>>>>>> d1094e4... Re-Modelled the whole lobby scene
    {
        if(collision.gameObject.GetComponentInChildren<PlayerController>() != null)
        {
            PlayerController characterScript = collision.gameObject.GetComponentInChildren<PlayerController>();
            characterScript.PickUp();
            Destroy(gameObject);
        }
    }
}
