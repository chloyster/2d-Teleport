using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//By Chris Gix


public class CandySpawner : MonoBehaviour
{

    public GameObject candy;
    private float timer = 10.0f;
    public Transform SpawnerA;
    public Transform SpawnerB;
    public Transform SpawnerC;
    public Transform SpawnerD;
    Transform[] spawns = new Transform[4];

    // Start is called before the first frame update
    void Start()
    {
        spawns[0] = SpawnerA;
        spawns[1] = SpawnerB;
        spawns[2] = SpawnerC;
        spawns[3] = SpawnerD;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            int newPos = Random.Range(0, 4);

            Collider2D pastCandy = Physics2D.OverlapCircle(spawns[newPos].position, 0.1f);

            if (pastCandy == null)
            {
                Instantiate(candy, spawns[newPos].position, spawns[newPos].rotation);
            }
            else
            {
                timer = 10.0f;
            }
        }
        timer -= Time.deltaTime;
    }
}
