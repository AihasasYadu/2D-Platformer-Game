using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponentInChildren<Ellen_Movement>() != null)
        {
            Ellen_Movement characterScript = collision.gameObject.GetComponentInChildren<Ellen_Movement>();
            characterScript.PickUp();
            Destroy(gameObject);
        }
    }
}
