using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//From "2D Platformer" tutorial in the Asset Store, published by Unity themselves

//Worked on by everyone in team

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public float strafeSpeed;
    public float jumpForce;
    public float extraGravity;
    private bool grounded = true;
    private bool canJump;
    private int surfacesTouching = 0;
    private float lastHealth;
    private bool onSpikes = false;
    private readonly float timeBetweenSpikeDmg = 0.5f;
    private float spikeTimeElapsed;
    public bool justTeleported;
    public bool haungsMode = false; //Vernon


    //private bool isDead; //gabriella

    public Animator animator; //gabriella

    private readonly float EPSILON = 0.001f;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        canJump = true;
        justTeleported = false;
        spikeTimeElapsed = timeBetweenSpikeDmg;
        AudioManager.instance.StopAllSounds();

        switch (SceneManager.GetActiveScene().name)
        {
            case "1Gabriella":
                break;
            case "2Vernon":
                AudioManager.instance.Play("Theme");
                break;
            case "3Dayton":
                AudioManager.instance.Play("Theme2");
                break;
            case "3.5SecretLevel":
                AudioManager.instance.Play("Theme2.5");
                break;
            case "4Chris":
                AudioManager.instance.Play("FinalBossTheme");
                AudioManager.instance.Play("EvilLaugh");
                break;
            default:
                AudioManager.instance.Play("Theme");
                break;
        }
        lastHealth = GameController.control.health;
    }


    void Update()
    {
        if (GameController.control.health <= 0)
        {
            //isDead = true;
            AudioManager.instance.Play("Die");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameController.control.health = lastHealth;
        }
        else
        {
            if (onSpikes)
            {
                if (spikeTimeElapsed <= 0)
                {
                    GameController.control.health--;
                    AudioManager.instance.Play("TakeDamage");
                    spikeTimeElapsed = timeBetweenSpikeDmg;
                }
                else
                {
                    spikeTimeElapsed -= Time.deltaTime;
                }
            }
        }
    }

    void FixedUpdate()
    {
        //old left/right movement
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //Vector2 movement = new Vector2(moveHorizontal, 0);
        //rb2d.AddForce(movement * speed);

        //haungs mode - player pressed "h"
        //By Vernon
        if (Input.GetKeyDown(KeyCode.H))
        {
            haungsMode = !haungsMode;
        }

        //new left/right movement
        float h = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(h * strafeSpeed, rb2d.velocity.y);

        if (haungsMode)
        {
            float v = Input.GetAxis("Vertical");
            rb2d.velocity = new Vector2(rb2d.velocity.x, v * strafeSpeed);
        }
        else
        {
            animator.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x)); //gabriella

            if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && System.Math.Abs(rb2d.velocity.y) < EPSILON && canJump && !justTeleported)
            {
                rb2d.AddForce(new Vector2(0, jumpForce));
            }

            rb2d.AddForce(new Vector2(0, -extraGravity));
        }

    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.name.StartsWith("Ground", System.StringComparison.Ordinal) || collision.gameObject.CompareTag("Ground")){
            //surfacesTouching++;
            //grounded = true;
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 center = collision.collider.bounds.center;
            if(contactPoint.y < center.y){
                canJump = false;
            }
            justTeleported = false;
        }
        
        if(collision.gameObject.name == "Death Zone")
        {
            AudioManager.instance.Play("Die");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            GameController.control.health--;
            AudioManager.instance.Play("TakeDamage");
        }
        else if (collision.gameObject.CompareTag("Spikes") || collision.gameObject.name.StartsWith("enemy"))
        {
            GameController.control.health--;
            AudioManager.instance.Play("TakeDamage");
            onSpikes = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.name.StartsWith("Ground", System.StringComparison.Ordinal) || collision.gameObject.CompareTag("Ground")
            || collision.gameObject.CompareTag("Spikes"))
        {
            surfacesTouching--;
            grounded = surfacesTouching > 0;
            canJump = true;
            onSpikes = false;
            spikeTimeElapsed = timeBetweenSpikeDmg;
        }
    }

    // gabriella additions:
    //void Death()
    //{
    //    if (isDead)
    //    {
    //        // play a death animation
    //        // bring up "Continue" screen, click to try again
    //        // start player with full health?
    //    }
    //}
}
