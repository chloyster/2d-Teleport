using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    // gabriella wrote this script
    public int sceneToLoad;

    IEnumerator OnCollisionEnter2D(Collision2D gameObjectInformation)
    {
        if (gameObjectInformation.gameObject.tag == "Player")
        {
            AudioManager.instance.Play("TelePad");

            yield return new WaitForSecondsRealtime(2.85f);

            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
