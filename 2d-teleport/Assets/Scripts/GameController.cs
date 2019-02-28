using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GameController : MonoBehaviour
{
    //gabriella wrote...
    public static GameController control;

    public float health;
    public int savedNPCs;

    void Awake()
    {
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }
    }

    public void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), "Health: " + health);
        GUI.Label(new Rect(10, 30, 100, 30), "Friends Saved: " + savedNPCs);
    }
}
