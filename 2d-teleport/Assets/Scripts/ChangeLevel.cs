using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public int sceneToLoad;
    void OnCollisionEnter2D(Collision2D gameObjectInformation)
    {
        if (gameObjectInformation.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
