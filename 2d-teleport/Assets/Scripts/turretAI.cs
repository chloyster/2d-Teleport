﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretAI : MonoBehaviour
{

    private bool inSight = false;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inSight)
        {
            Vector3 difference = target.transform.position - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
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
}
