using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //camera movement from YouTube tutorial:
    //https://youtu.be/BQEsbOALKhc

    private Vector2 velocity;
    private Vector3 cameraToPlayer;

    public float smoothTimeX;
    public float smoothTimeY;
    public float boundingCircleSize;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cameraToPlayer = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cameraToPlayer = player.transform.position - transform.position;

        if (playerOutsideBounds())
        {
            float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
            float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
            
            transform.position = new Vector3(posX, posY, transform.position.z);
        }

    }

    private bool playerOutsideBounds()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > boundingCircleSize)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
