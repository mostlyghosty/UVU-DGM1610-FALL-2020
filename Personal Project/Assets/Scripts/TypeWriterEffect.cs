﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriterEffect : MonoBehaviour
{
    //the delay it will wait before showing each new character
    public float delay = 0.07f;

    //What is shown when the text is fully displayed
    public string fullText;

    //when to start the typewriter
    public bool textVar;

    //starts empty
    private string currentText = "";

    //SFX
    public AudioClip[] textClips;

    private AudioSource playerAudio;

    //The dialogue box
    public Text dialogueBox;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        //when dialogue sends over information, start the typewriter effect
        if (textVar)
        {
            textVar = false;
            StartCoroutine(ShowText ());
        }
    }

    IEnumerator ShowText ()
    {
        //for the number of characters in full text plus 1
        for (int i = 0; i < (fullText.Length + 1); i++)
        {
            //make current text a substring of full text, substring goes from 0 to i
            currentText = fullText.Substring(0,i);

            //sets the text based on what is in current text
            this.GetComponent<Text>().text = currentText;

            //once there is once character on the screen start the sound generator for each character that is displayed
            if (i > 1)
            {
                Invoke("RandomSoundGenerator", 0);
            }

            //must use IEnumerator function to use WaitForSeconds, sets delay between when characters show up
            yield return new WaitForSeconds(delay);
        }

        //clears dialogue
        StartCoroutine("ClearDialogue");
    }

    void RandomSoundGenerator()
    {
        //chooses a random sound to play when a character is displayed
        playerAudio.PlayOneShot(textClips[Random.Range(0, textClips.Length)], 0.1f);
    }

    //clears Dialogue after 2 seconds
     IEnumerator ClearDialogue()
    {
        yield return new WaitForSecondsRealtime(2f);
        dialogueBox.text = null;
    }
}
