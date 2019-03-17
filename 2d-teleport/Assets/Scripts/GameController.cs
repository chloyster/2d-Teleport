using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class GameController : MonoBehaviour
{
    //gabriella wrote this script
    public static GameController control;

    // HUD health stuff
    public Slider healthSlider;
    public Image damageImage;

    public float maxHealth;
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

    void Update()
    {
        healthSlider.value = health;
    }
    //public void OnGUI()
    //{
    //    GUIStyle myStyle = new GUIStyle();
    //    myStyle.fontSize = 50;
    //    GUI.Label(new Rect(10, 10, 100, 30), "Health: " + health, myStyle);
    //    GUI.Label(new Rect(10, 60, 100, 30), "Friends Saved: " + savedNPCs, myStyle);
    //}
}
