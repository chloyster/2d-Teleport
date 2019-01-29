using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public float speed;
    public float jumpForce;
    private bool grounded = true;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb2d.AddForce(movement * speed);

        if(Input.GetKeyDown(KeyCode.Space) && grounded == true){
            rb2d.AddForce(new Vector2(0, jumpForce));
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
