using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyControl : MonoBehaviour
{
    // Gabriella wrote this script
    // Start is called before the first frame update
    public float speed = 2f;
    public float maxRotation = 5f;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, maxRotation * Mathf.Sin(Time.time * speed));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameController.control.health <= 10)
            {
                GameController.control.health += 1;
            }
            gameObject.SetActive(false);
        }
    }
}
