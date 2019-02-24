using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    public float speed = 1.0f;
    public float lifeTime = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }



    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyProjectile();
    }
}
