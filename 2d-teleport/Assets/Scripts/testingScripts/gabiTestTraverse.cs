using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gabiTestTraverse : MonoBehaviour
{
    public int sceneToLoad;

    public void NextLevel()
    {
        Application.LoadLevel(sceneToLoad);
    }
}
