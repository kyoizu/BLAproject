using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, jumpHeight;
    float velX, velY;
    Rigidbody2D rb;
    public Transform groundcheck;
    public bool isGrounded;
    public float groundCheckRadius;
    public bool isFaceRight = true;
    public LayerMask whatIsGround;
    Animator anim;
    AudioManager audioManager;
    public GameObject melee;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += DisablePlayerMove;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= DisablePlayerMove;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        EnablePlayerMove();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, groundCheckRadius, whatIsGround);
        if (isGrounded)
        {
            anim.SetBool("Jump", false);
        }
        else
        {
            anim.SetBool("Jump", true);
        }

        FlipCharacter();
        Attack();
        Jump();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void Attack()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            audioManager.PlaySFX(audioManager.playerAtkSword);
            anim.SetBool("Attack", true);
            melee.SetActive(true);
        }
        else
        {
            anim.SetBool("Attack", false);
            melee.SetActive(false);
        }
    }

    //public void Shoot() 
    //{
    //    if(Input.GetButtonDown("Fire"))
    //    {
    //        
    //    }
    //}

    public void Jump()
    {
        if(isGrounded && Input.GetButton("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }

    public void Movement()
    {
        velX = Input.GetAxisRaw("Horizontal");
        velY = rb.velocity.y;
        rb.velocity = new Vector2(velX * speed, velY);

        if(rb.velocity.x != 0)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
    }

    public void FlipCharacter()
    {
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isFaceRight = true;
        }
        else if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isFaceRight = false;
        }
    }

    private void DisablePlayerMove()
    {
        anim.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void EnablePlayerMove()
    {
        anim.enabled = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}