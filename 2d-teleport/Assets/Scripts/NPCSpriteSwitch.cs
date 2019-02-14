using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gabriella
public class NPCSpriteSwitch : MonoBehaviour
{
    public Sprite sprite1; // Drag your first sprite here
    public Sprite sprite2; // Drag your second sprite here

    //AudioSource foundSound;
    private SpriteRenderer spriteRenderer;
    private bool playerFound = false;

    void Start()
    {
        //foundSound = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = sprite1; // set the sprite to sprite1
    }

    void Update()
    {
        if (playerFound) // If the player collides with the NPC
        {
            ChangeTheDamnSprite(); // call method to change sprite
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerFound = true;
            AudioManager.instance.Play("RescuedKid");
            //foundSound.Play();
        }
    }

    void ChangeTheDamnSprite()
    {
        if (spriteRenderer.sprite == sprite1) // if the spriteRenderer sprite = sprite1 then change to sprite2
        {
            spriteRenderer.sprite = sprite2;
        }
        //else
        //{
        //    spriteRenderer.sprite = sprite1; // otherwise change it back to sprite1
        //}
    }
}
