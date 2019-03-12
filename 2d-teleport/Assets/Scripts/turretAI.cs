using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretAI : MonoBehaviour
{
    //Health of enemy
    public float health;

    private bool inSight = false;
    private Transform target;
    public GameObject bullet;
    private float timer = 1.0f;
    public Transform shotpoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inSight && timer <= 0)
        {
            if (tag == "Boss" && target.position.x < transform.position.x)
            {
                shotpoint.position = new Vector3(transform.position.x - 2.712f, transform.position.y - 0.14f, 0);
            }
            else if (tag == "Boss" && target.position.x > transform.position.x)
            {
                shotpoint.position = new Vector3(transform.position.x + 2.712f, transform.position.y - 0.14f, 0);
            }
            Vector3 difference = target.transform.position - shotpoint.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            shotpoint.rotation = Quaternion.Euler(0f, 0f, rotZ);
            GameObject turrBullet = Instantiate(bullet, shotpoint.position, shotpoint.rotation);
            timer = 1.0f;
        }
        timer -= Time.deltaTime;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("Projectile"))
        {
            health--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            inSight = true;
            target = collision.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            inSight = false;
        }
    }
}
