using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float speed = 10f;
    public float horizontal;
    public float jumpSpeed = 12f;
    public bool facingRight = true;
    public Animator anim;
    public Rigidbody rb;
    private SpriteRenderer _spriteRenderer;
    
    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        
        Flip();
    }
    private void Flip()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            _spriteRenderer.flipX = false;
        }
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }
    private void Die()
    {
        anim.SetTrigger("Death");
    }
}
