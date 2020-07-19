using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int weakenPlayerBy;
    public int enemySpeed;
    private Ellen_Movement characterScript;
    public GameObject player;
    private Vector2 pos;
    private Animator chomperAnim;
<<<<<<< HEAD
    public int directionControl;
=======
>>>>>>> d1094e4... Re-Modelled the whole lobby scene
    private int movementLimit = 12;
    private SpriteRenderer mySpriteRenderer;
    private int playerLayer = 8;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponentInChildren<PlayerController>() != null)
        {
            PlayerController gameCharacter = collision.gameObject.GetComponentInChildren<PlayerController>();
            gameCharacter.DecreaseHealth(weakenPlayerBy);
        }
        else if(collision.gameObject.layer.Equals(movementLimit))
        {
            directionControl *= -1;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(playerLayer))
        {
            chomperAnim.SetBool("isCharacterNear", true);
            PlayerDirection();
            Direction(directionControl);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(playerLayer))
        {
            chomperAnim.SetBool("isCharacterNear", false);
        }
    }

    private void Start()
    {
        chomperAnim = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!chomperAnim.GetBool("isCharacterNear"))
        {
            Move();
        }
    }

    private void PlayerDirection()
    {
        if((transform.position.x - player.transform.position.x) < 0)
        {
            directionControl = 1;
        }
        else if((transform.position.x - player.transform.position.x) > 0)
        {
            directionControl = -1;
        }
    }

    private void Direction(float x)
    {
        if (x < 0)
        {
            mySpriteRenderer.flipX = true;
        }
        else if (x > 0)
        {
            mySpriteRenderer.flipX = false;
        }
    }

    private void Move()
    {
        pos = transform.position;
        pos.x += directionControl * enemySpeed * Time.deltaTime;
        transform.position = pos;
        Direction(directionControl);
        chomperAnim.SetInteger("Speed", enemySpeed);
    }
}
