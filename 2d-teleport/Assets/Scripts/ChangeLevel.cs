using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D gameObjectInformation)
    {
        Debug.Log("I'm in");
        if (gameObjectInformation.gameObject.tag == "Player")
        {
            Debug.Log("Collision Detected");
            SceneManager.LoadScene("Level2");
        }
    }
}
