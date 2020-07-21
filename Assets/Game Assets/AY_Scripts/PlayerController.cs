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
    public float height = 2;
    public int walkSpeed;
    public int sprintSpeed;

    [HideInInspector] public int health = 100;
    [HideInInspector] public int levelIndex;
    [HideInInspector] public int score;
    [HideInInspector] public float boxCollider2dCrouchSizeX = 0.89f;
    [HideInInspector] public float boxCollider2dCrouchSizeY = 1.32f;
    [HideInInspector] public float boxCollider2dCrouchOffsetX = -0.12f;
    [HideInInspector] public float boxCollider2dCrouchOffsetY = 0.57f;
    [HideInInspector] public float boxCollider2dSizeX = 0.59f;
    [HideInInspector] public float boxCollider2dSizeY = 2.07f;
    [HideInInspector] public float boxCollider2dOffsetX = 0.021f;
    [HideInInspector] public float boxCollider2dOffsetY = 0.95f;
    [HideInInspector] public bool freeze;
    /*-------------------------------------------------------------*/

    //Private Variables
    private float speed;
    private float directionControl;
    private int groundLayer = 9;
    private int deathLine = 10;
    private int Jump_Count_Check;
    private Animator anime;
    private Rigidbody2D rigidBody2d;
    private SpriteRenderer mySpriteRenderer;
    private BoxCollider2D box_collider2D;
    /*-------------------------------------------------------------*/
    //Animation Variables
    private string onGroundAnimParameter = "OnGround";
    private string deathAnimParameter = "Death";
    private string deathAnimName = "Ellen_Death";
    private string crouchAnimParameter = "isCrouch";
    private string crouchAnimName = "Ellen_Crouch";
    private string groundTriggeredAnimName = "Ellen_Ground_Trigger";
    private string firstJumpAnimParameter = "First_Jump";
    private string speedAnimParameter = "Speed";
    /*-------------------------------------------------------------*/
    //Prefab Variables
    private string prefabHealth = "PlayerHealth";
    private string prefabLevel = "LastLevel";
    /*-------------------------------------------------------------*/
    //Audio Names
    private string gameOverSound = "GameOverSound";
    private string landingSound = "LandingSound";

    private void Awake()
    {
        health = PlayerPrefs.GetInt(prefabHealth, 100);
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        box_collider2D = GetComponent<BoxCollider2D>();
        rigidBody2d = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        freeze = false;
    }

    private void Update()
    {
        if (!anime.GetBool(deathAnimParameter) && !freeze)
        {
            HorzMovement();
            Jump();
            Crouch();
        }
        else
        {
            FreezePlayer();
        }
    }

    private void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anime.SetBool(crouchAnimParameter, !anime.GetBool(crouchAnimParameter));
            if (anime.GetBool(crouchAnimParameter) == true)
            {
                anime.Play(crouchAnimName, -1, 0f);
                box_collider2D.size = new Vector2(boxCollider2dCrouchSizeX, boxCollider2dCrouchSizeY);
                box_collider2D.offset = new Vector2(boxCollider2dCrouchOffsetX, boxCollider2dCrouchOffsetY);
            }
            if (anime.GetBool(crouchAnimParameter) == false)
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
                anime.SetBool(firstJumpAnimParameter, true);
                rigidBody2d.AddForce(transform.up * height, ForceMode2D.Force);
                anime.SetBool(onGroundAnimParameter, false);
                Jump_Count_Check++;
            }
            else if (isJumpKeyPressed() && !isOnGround() && isSecondJump())
            {
                anime.SetBool(firstJumpAnimParameter, true);
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
        if (anime.GetBool(onGroundAnimParameter))
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
        anime.SetFloat(speedAnimParameter, horzSpeed);
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
        anime.Play(deathAnimName, -1, 0f);
        anime.SetBool(deathAnimParameter, true);
        FreezePlayer();
        PlayerPrefs.SetInt(prefabLevel, SceneManager.GetActiveScene().buildIndex);
        gameOverController.playerDead = true;
        FindObjectOfType<AudioManagerController>().Play(gameOverSound);
        gameOverController.GameOverOverlay();
    }
    public void FreezePlayer()
    {
        rigidBody2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
        rigidBody2d.gravityScale = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer.Equals(groundLayer) && !anime.GetBool(deathAnimParameter))
        {
            anime.SetBool(onGroundAnimParameter, true);
            FindObjectOfType<AudioManagerController>().Play(landingSound);
            Jump_Count_Check = 0;
            anime.Play(groundTriggeredAnimName, -1, 0f);
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
            anime.SetBool(onGroundAnimParameter, false);
        }
    }

}
