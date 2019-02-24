using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    // Gabriella wrote:

    public Text textDisplay;
    public string[] sentences;

    public float typingSpeed;
    private int index;

    public GameObject continueButton;

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
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed); // check this
        }
    }

    public void NextSentence()
    {
        Debug.Log("got to next sentence");

        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
            Debug.Log("here2");
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            Debug.Log("here3");

        }
    }

}
