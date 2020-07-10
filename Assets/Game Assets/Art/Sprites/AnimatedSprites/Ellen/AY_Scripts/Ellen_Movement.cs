using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Ellen_Movement : MonoBehaviour
{
    public Animator anime;
    public float speed = 2;
    public float height = 2;
    private Rigidbody2D rb;
    private SpriteRenderer mySpriteRenderer;
    Collision2D collision;
    BoxCollider2D bc;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer.Equals(9))
        {
            anime.SetBool("OnGround", true);
        }
        else
        {
            anime.SetBool("OnGround", false);
        }
    }

    private void Awake()
    {
        // get a reference to the SpriteRenderer component on this gameObject
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        rb = GetComponentInParent<Rigidbody2D>();
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
                bc.size = new Vector2(0.89f, 1.32f);
                bc.offset = new Vector2(-0.12f, 0.57f);
            }
            if (anime.GetBool("isCrouch") == false)
            {
                bc.size = new Vector2(0.59f, 2.07f);
                bc.offset = new Vector2(0.021f, 0.95f);
            }
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            /*anime.Play("Ellen_Jump", -1, 0f);*/
            anime.SetBool("Jump1", true);
            Vert_Movement();
            /*anime.SetBool("First_Jump", true);*/
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vert_Movement();
                anime.SetBool("Second_Jump", true);
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                anime.SetBool("Second_Jump", false);
            }
        }
        /*else if (Input.GetKeyUp(KeyCode.Space))
        {
            anime.SetBool("J", false);
        }*/
    }

    public void Vert_Movement()
    {
        /*Vector2 jump = transform.parent.position;
        jump.y += height * Time.deltaTime;*/
        rb.AddForce(transform.up * height);
    }

    public void Horz_Movement()
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
