using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 1.0f;
    public float lifeTime = 1.5f;
    public GameObject prevShot = null;

    //public GameObject destroyEffect;
    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyProjectile();
    }

}
