using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Pathfinding;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class enemyAI : MonoBehaviour
{

    public Text win;

    //Health of enemy
    public float health;

    //object we are chasing
    public Transform target;

    //how many times each second we will update our path
    public float updateRate = 2f;

    //caching
    private Seeker seeker;
    private Rigidbody2D rb;

    //The calculated path
    public Path path;

    //The AI's speed per second
    public float speed = 300f;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;

    //Max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3f;

    //the waypoint we are currently moving towards
    private int currentWaypoint = 0;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if(target == null)
        {
            return;
        }
        //start a new path to the target position, return the result to the onpath complete method.
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());
    }

    IEnumerator UpdatePath()
    {
        if(target == null)
        {
            //TODO: Insert a player search here
            yield return false;
        }
        //start a new path to the target position, return the result to the onpath complete method.
        seeker.StartPath(transform.position, target.position, OnPathComplete);
        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());

    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("We got a path." + p.error);
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        if(target == null)
        {
            //TODO: Insert a player search here
            return;
        }

        //TODO: Always look at player

        if(path == null)
        {
            return;
        }
        //If we reached our final waypoint
        if(currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
            {
                return;
            }
            Debug.Log("End of path reached.");
            pathIsEnded = true;
            return;
        }
        pathIsEnded = false;

        //Direction to next waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        //fixed deltatime because we are in fixed update
        dir *= speed * Time.fixedDeltaTime;

        //Move the AI
        rb.AddForce(dir, fMode);

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);

        if(dist < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }
    }

    void Update()
    {
        if(health <= 0)
        {
            if(tag == "Boss")
            {
                win.gameObject.SetActive(true);
            }
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
        if(collision.gameObject.name == "Player" && target == null)
        {
            target = collision.gameObject.transform;
            StartCoroutine(UpdatePath());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && target != null)
        {
            rb.velocity = Vector2.zero;
            StopCoroutine(UpdatePath());
            target = null;

        }
    }
}
