using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float offset;

    public GameObject projectile;
    public GameObject player;
    public Transform shotPoint;

    private float timeBtwnShots;
    private GameObject lastProjectile;
    public float startTimeBtwShots;

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBtwnShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                lastProjectile = Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBtwnShots = startTimeBtwShots;
            }
            else if (Input.GetMouseButtonDown(1))
            {
                player.transform.position = lastProjectile.transform.position;
                Destroy(lastProjectile);
            }
        }
        else
        {
            timeBtwnShots -= Time.deltaTime;
        }

    }
}
