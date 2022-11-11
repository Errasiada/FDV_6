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
    [SerializeField] private Rigidbody2D rb;
    
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
        if (facingRight && horizontal < 0f || !facingRight && horizontal > 0f)
        {
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
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
