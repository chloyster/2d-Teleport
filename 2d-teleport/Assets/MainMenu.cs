using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Gabriella wrote this script
    public void Start()
    {
        AudioManager.instance.Play("Theme");
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("1Gabriella");
    }    
    public void QuitGame()
    {
        Debug.Log("QuitGame!");
        Application.Quit();
    }
}
