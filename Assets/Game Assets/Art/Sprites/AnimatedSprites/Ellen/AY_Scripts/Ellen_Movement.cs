using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Ellen_Movement : MonoBehaviour
{
    public Animator anime;
    public float speed = 2;
    public float height = 2;
    public float boxCollider2dCrouchSizeX = 0.89f;
    public float boxCollider2dCrouchSizeY = 1.32f;
    public float boxCollider2dCrouchOffsetX = -0.12f;
    public float boxCollider2dCrouchOffsetY = 0.57f;
    public float boxCollider2dSizeX = 0.59f;
    public float boxCollider2dSizeY = 2.07f;
    public float boxCollider2dOffsetX = 0.021f;
    public float boxCollider2dOffsetY = 0.95f;
    private int groundLayer = 9;
    private int deathLine = 10;
    private float delayTimeBy = 0.2f;
    private int Jump_Count_Check;
    private Rigidbody2D rigidBody2d;
    private SpriteRenderer mySpriteRenderer;
    private Collision2D collision;
    private BoxCollider2D box_collider2D;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("In Collision Enter");
        if (collision.gameObject.layer.Equals(groundLayer))
        {
            Debug.Log("In Collision Enter IF");
            anime.SetBool("OnGround", true);
            Jump_Count_Check = 0;
            anime.Play("Ellen_Ground_Trigger", -1, 0f); 
            Debug.Log("Leaving In Collision Enter IF");
        }
        else if (collision.gameObject.layer.Equals(deathLine))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private IEnumerator OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("In Collision Exit");
        if (collision.gameObject.layer.Equals(groundLayer) && Jump_Count_Check >= 1)
        {
            Debug.Log("In Collision Exit If");
            yield return new WaitForSeconds(delayTimeBy);
            anime.SetBool("OnGround", false);
            Debug.Log("Leaving In Collision Exit if");
        }
    }

    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        box_collider2D = GetComponent<BoxCollider2D>();
        rigidBody2d = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Horz_Movement();
        Jump();
        Crouch();
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
        if (Input.GetKeyDown(KeyCode.Space) && anime.GetBool("OnGround") && Jump_Count_Check < 2)
        {
            Debug.Log("Jump1 : " + Jump_Count_Check);
            anime.SetBool("First_Jump", true);
            rigidBody2d.AddForce(transform.parent.up * height, ForceMode2D.Force);
            if (Input.GetKeyUp(KeyCode.Space))
            {
                /*StartCoroutine(Delay());*/
                anime.SetBool("OnGround", false);
            }
            Jump_Count_Check++;
        }
    }

    private void Horz_Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        anime.SetFloat("Speed", Mathf.Abs(horizontal));
        Direction(horizontal);
        Vector2 pos = transform.parent.position;
        pos.x += horizontal * speed * Time.deltaTime;
        transform.parent.position = pos;
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
}
