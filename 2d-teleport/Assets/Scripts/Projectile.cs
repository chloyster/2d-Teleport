using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//By Dayton
public class Projectile : MonoBehaviour
{
    public float speed = 1.0f;
    public float lifeTime = 1.5f;
    public GameObject prevShot = null;
    public GameObject nextShot = null;

    public GameObject weapon = null;

    //public GameObject destroyEffect;
    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public void DestroyProjectile()
    {
        if (nextShot == null)
        {
            weapon.GetComponent<Weapon>().lastProjectile = prevShot;
        }
        else
        {
            nextShot.GetComponent<Projectile>().prevShot = prevShot;
        }
        if (prevShot != null)
        {
            prevShot.GetComponent<Projectile>().nextShot = nextShot;
        }
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyProjectile();
    }

}
