﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//From "2D Platformer" tutorial in the Asset Store, published by Unity themselves
public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public float strafeSpeed;
    public float jumpForce;
    public float extraGravity;
    private bool grounded = true;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        //old left/right movement
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //Vector2 movement = new Vector2(moveHorizontal, 0);
        //rb2d.AddForce(movement * speed);

        //new left/right movement
        float h = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(h * strafeSpeed, rb2d.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && grounded == true){
            rb2d.AddForce(new Vector2(0, jumpForce));
        }
        if (grounded == false)
        {
            rb2d.AddForce(new Vector2(0, -extraGravity));
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.name.StartsWith("Ground", System.StringComparison.Ordinal)){
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.name.StartsWith("Ground", System.StringComparison.Ordinal)){
            grounded = false;
        }
    }
}
