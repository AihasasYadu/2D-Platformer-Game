using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Public Variables
    public int weakenPlayerBy;
    public int enemySpeed;
    public GameObject player;
    public int directionControl;
    /*-------------------------------------------------------------*/

    //Private Variables
    private Vector2 pos;
    private Animator chomperAnim;
    private int health;
    private int movementLimit = 12;
    private SpriteRenderer mySpriteRenderer;
    private int playerLayer = 8;
    private string characterNearCondition = "isCharacterNear";
    private string speedAnimParameter = "Speed";
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
        if (collision.gameObject.layer.Equals(14))
        {
            Damage(50);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(playerLayer))
        {
            chomperAnim.SetBool(characterNearCondition, true);
            PlayerDirection();
            Direction(directionControl);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(playerLayer))
        {
            chomperAnim.SetBool(characterNearCondition, false);
        }
    }

    private void Start()
    {
        health = 100;
        chomperAnim = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!isCharacterNear())
        {
            Move();
        }
    }
    private bool isCharacterNear()
    {
        if (chomperAnim.GetBool(characterNearCondition))
            return true;
        else
            return false;
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
        chomperAnim.SetInteger(speedAnimParameter, enemySpeed);
    }

    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            chomperAnim.SetBool("isDead", true);
            StartCoroutine(Delay(1));
            gameObject.SetActive(false);
        }
    }

    IEnumerator Delay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
