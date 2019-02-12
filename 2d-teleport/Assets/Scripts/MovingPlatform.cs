using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//moving platform tutorial: https://www.youtube.com/watch?v=4R_AdDK25kQ

public class MovingPlatform : MonoBehaviour
{
    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nextPos;


    public float speed;

    public Transform platformToMove;   //the moving platform itself.

    public Transform moveTo;   //the location the platform should move to.

    // Start is called before the first frame update
    void Start()
    {
        posA = platformToMove.localPosition;
        posB = moveTo.localPosition;
        nextPos = posB;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        platformToMove.localPosition = Vector3.MoveTowards(platformToMove.localPosition, nextPos, speed * Time.deltaTime);

        if (Vector3.Distance(platformToMove.localPosition, nextPos) <= 0.1)
        {
            ChangeDestination();
        }
    }

    private void ChangeDestination()
    {
        nextPos = (nextPos != posA ? posA : posB);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.SetParent(platformToMove);
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        other.transform.SetParent(null);
    }

}
