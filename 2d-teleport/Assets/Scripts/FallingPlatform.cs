// This script was written by Vernon.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private BoxCollider2D boxCollider;
    public float fallDelaySeconds;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        boxCollider = GetComponentInChildren<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Fall());
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelaySeconds);
        rb2d.isKinematic = false;
        boxCollider.enabled = false;

        yield return 0;
    }
}
