using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    //Public Variables
    public ScoreController scoreController;
    public GameOverController gameOverController;
    public Animator anime;
    public float height = 2;
    public int score;
    public int walkSpeed;
    public int sprintSpeed;
<<<<<<< HEAD:Assets/Game Assets/AY_Scripts/Ellen_Movement.cs
=======

    [HideInInspector]
    public int health = 100;
    public int levelIndex;
    public int score;
>>>>>>> d1094e4... Re-Modelled the whole lobby scene:Assets/Game Assets/AY_Scripts/PlayerController.cs
    public float boxCollider2dCrouchSizeX = 0.89f;
    public float boxCollider2dCrouchSizeY = 1.32f;
    public float boxCollider2dCrouchOffsetX = -0.12f;
    public float boxCollider2dCrouchOffsetY = 0.57f;
    public float boxCollider2dSizeX = 0.59f;
    public float boxCollider2dSizeY = 2.07f;
    public float boxCollider2dOffsetX = 0.021f;
    public float boxCollider2dOffsetY = 0.95f;
    /*-------------------------------------------------------------*/

    //Private Variables
    private float speed;
    private float directionControl;
    private int groundLayer = 9;
    private int deathLine = 10;
    private int Jump_Count_Check;
    private Rigidbody2D rigidBody2d;
    private SpriteRenderer mySpriteRenderer;
    private BoxCollider2D box_collider2D;

    private void Awake()
    {
        PlayerPrefs.GetInt("PlayerLives", health);
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        box_collider2D = GetComponent<BoxCollider2D>();
        rigidBody2d = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (!anime.GetBool("Death"))
        {
            HorzMovement();
            Jump();
            Crouch();
        }
    }

    private void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anime.SetBool("isCrouch", !anime.GetBool("isCrouch"));
            if (anime.GetBool("isCrouch") == true)
            {
                anime.Play("Ellen_Crouch", -1, 0f);
                box_collider2D.size = new Vector2(boxCollider2dCrouchSizeX, boxCollider2dCrouchSizeY);
                box_collider2D.offset = new Vector2(boxCollider2dCrouchOffsetX, boxCollider2dCrouchOffsetY);
            }
            if (anime.GetBool("isCrouch") == false)
            {
                box_collider2D.size = new Vector2(boxCollider2dSizeX, boxCollider2dSizeY);
                box_collider2D.offset = new Vector2(boxCollider2dOffsetX, boxCollider2dOffsetY);
            }
        }
    }

    private void Jump()
    {
        if (Jump_Count_Check < 2)
        {
            if (isJumpKeyPressed() && isOnGround())
            {
                anime.SetBool("First_Jump", true);
                rigidBody2d.AddForce(transform.up * height, ForceMode2D.Force);
                anime.SetBool("OnGround", false);
                Jump_Count_Check++;
            }
            else if (isJumpKeyPressed() && !isOnGround() && isSecondJump())
            {
                anime.SetBool("First_Jump", true);
                rigidBody2d.AddForce(transform.up * height, ForceMode2D.Force);
                Jump_Count_Check++;
            }
        }
        else
        {
            Jump_Count_Check = 0;
        }
    }

    private bool isJumpKeyPressed()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool isOnGround()
    {
        if (anime.GetBool("OnGround"))
            return true;
        else
            return false;
    }

    private bool isSecondJump()
    {
        if (Jump_Count_Check > 0)
            return true;
        else
            return false;
    }

    private void HorzMovement()
    {
        float horzSpeed = 0.5f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            horzSpeed = 1;
            speed = sprintSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
        directionControl = Input.GetAxisRaw("Horizontal");
        if (directionControl == 0)
        {
            horzSpeed = 0;
        }
        anime.SetFloat("Speed", horzSpeed);
        Direction(directionControl);
        Vector2 pos = transform.position;
        pos.x += directionControl * speed * Time.deltaTime;
        transform.position = pos;
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

    public void PickUp()
    {
        scoreController.ScoreUpdate(10);
    }

    public void DecreaseHealth(int decreaseHealthBy)
    {
        health -= decreaseHealthBy;
        if (health <= 0)
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        anime.Play("Ellen_Death", -1, 0f);
        anime.SetBool("Death", true);
        rigidBody2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        PlayerPrefs.SetInt("LastLevel", SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Index : " + SceneManager.GetActiveScene().buildIndex);
        gameOverController.playerDead = true;
        gameOverController.GameOverOverlay();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer.Equals(groundLayer) && !anime.GetBool("Death"))
        {
            anime.SetBool("OnGround", true);
            Jump_Count_Check = 0;
            anime.Play("Ellen_Ground_Trigger", -1, 0f);
        }
        else if (collision.gameObject.layer.Equals(deathLine))
        {
            KillPlayer();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer.Equals(groundLayer))
        {
            anime.SetBool("OnGround", false);
        }
    }

}
