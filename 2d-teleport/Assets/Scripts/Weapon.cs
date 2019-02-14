using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float offset;

    public GameObject projectile;
    public GameObject player;
    public Transform shotPoint;
    public CameraShake cameraShake;

    private float timeBtwnShots;
    public GameObject lastProjectile;
    public float startTimeBtwShots;

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBtwnShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                AudioManager.instance.Play("BulletFire");
                GameObject lProjectile = Instantiate(projectile, shotPoint.position, transform.rotation);
                lProjectile.GetComponent<Projectile>().weapon = gameObject;

                lProjectile.GetComponent<Projectile>().prevShot = lastProjectile;
                if (lastProjectile != null)
                {
                    lastProjectile.GetComponent<Projectile>().nextShot = lProjectile;
                }

                lastProjectile = lProjectile;
                timeBtwnShots = startTimeBtwShots;
            }
            else if (Input.GetMouseButtonDown(1))
            {
                if (lastProjectile != null)
                {
                    AudioManager.instance.Play("TP");
                    StartCoroutine(cameraShake.Shake(.05f, .2f));
                    player.transform.position = lastProjectile.transform.position;
                    Rigidbody2D playerrb = player.GetComponent<Rigidbody2D>();
                    if (playerrb.velocity.y < 0)
                    {
                        float xVel = playerrb.velocity.x;
                        playerrb.velocity = new Vector2(xVel, 0);
                    }
                    //GameObject lProjectile = lastProjectile.GetComponent<Projectile>().prevShot;
                    //Destroy(lastProjectile);
                    //lastProjectile = lProjectile;
                    lastProjectile.GetComponent<Projectile>().DestroyProjectile();
                }
            }
        }
        else
        {
            timeBtwnShots -= Time.deltaTime;
        }

    }
}
