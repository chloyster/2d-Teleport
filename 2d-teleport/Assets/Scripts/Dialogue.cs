using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    // Gabriella wrote this script

    public Text textDisplay;
    public string[] sentences;

    public float typingSpeed;
    private int index;


    public GameObject continueButton;
    public GameObject player;
    public GameObject wakeAnim;

    public bool skippedIntro;

    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    void Start()
    {
        StartCoroutine(Type());
        skippedIntro = false;
    }

    IEnumerator Type()
    {
        AudioManager.instance.Play("Bear" + ((index % 3) + 1));
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed); // check this
        }
    }

    public void SkipIntro()
    {
        skippedIntro = true;
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        if (index < sentences.Length - 1 && skippedIntro == false)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            player.SetActive(true);
            wakeAnim.SetActive(false);
            // all sentences have been read
        }
    }

}
