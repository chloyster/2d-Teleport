// This script was written by Vernon.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingPlatform : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private bool doRising = false;
    public float riseDelaySeconds;
    public float riseSpeed = 0.1f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Rise());
        }
    }

    void FixedUpdate()
    {
        if (doRising == true)
        {
            rb2d.MovePosition(rb2d.position + new Vector2(0f, riseSpeed));
        }
    }

    IEnumerator Rise()
    {
        yield return new WaitForSeconds(riseDelaySeconds);

        doRising = true;



        yield return 0;
    }
}
