using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSceneManager : MonoBehaviour
{

    // gabriella wrote this...

    public GameObject dialogueManager;
    public Animator wakeUpanim;
    
    void Start()
    {
        dialogueManager.SetActive(false);
    }

    public void StartDialogue()
    {
        dialogueManager.SetActive(true);
    }
}
