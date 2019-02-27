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

    //note: try animating the character to stand up, then play the dialogue,
    //      then set the player to active, then let them run
}
