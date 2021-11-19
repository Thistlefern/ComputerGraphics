using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PumpkinCranky : MonoBehaviour
{
    bool inRange;           // checks if player is in range
    public Text interact;   // the object that holds the interectText

    readonly string[] sentences = new string[7]; // array that holds the sentences
    public int whichSentence;           // number which determines which sentence from the array is the current focus

    public GameObject talkBox;
    public GameObject profile;
    string inputText;           // grabs a sentence from the sentences array per the whichSentence number
    public char[] letters;      // takes the sentence above, one letter at a time
    public char[] output;       // will populate with the stored sentence as time goes on
    public int currentLetter;   // keeps track of where in the stored sentence needs to be printed to output next
    float timer;                // keeps track of the time since the last letter was printed
    public float timeInterval;  // the time between letters being printed
    public Text text;           // the object that prints the output
    public Text cont;           // the object that prints the text to continue once the sentence has been fuly printed

    public new AudioSource audio;   // audio source for the sound of talking
    public AudioClip clip;          // clip of talking
    bool talking;                   // checks if the character is currently talking

    public PlayerController player;     // the player
    public UIScriptSpooky ui;

    private void OnTriggerEnter(Collider other)     // when the player enters the area of a TRIGGER collider connected to this script...
    {
        inRange = true;                             // ...note that the player is within range...
        interact.text = "Press E to interact";      // ...and set the interact text to give the player instructions
    }
    private void OnTriggerExit(Collider other)      // when the player leaves the ares of a TRIGGER collider connected to this script...
    {
        inRange = false;                            // ...note that the player is no longer within range...
        interact.text = "";                         // ...and remove the interact text
    }

    void Start()
    {
        interact.text = "Press E to interact";      // in this use case, the player starts the game in the range of the object. THIS WILL NOT ALWAYS BE THE CASE
        inRange = true;                             // ^^^

        #region sentences
        sentences[0] = "Happy All Hallows Eve, bud.";
        sentences[1] = "A bunch of teenagers got scared off when you woke up.";
        sentences[2] = "It was pretty funny to watch, honestly.";
        sentences[3] = "But, as usual, teenagers can't exist without making a mess, can they?";
        sentences[4] = "Mind cleaning up the candy they left behind? It really kills the spooky vibe.";
        sentences[5] = "Use WASD to move, Left Shift to run, and Space to jump. Escape lets you pause.";
        sentences[6] = "Ask my friend up on that headstone for hints if you need them.";
        #endregion

        whichSentence = 0;                          // set to 0 so as to use the first sentence in the sentences array when talking starts
        inputText = sentences[whichSentence];       // set up the initial input text
        letters = inputText.ToCharArray();          // push the letters from the string of inputText into an array

        currentLetter = 1;                          // set starting letter to 1 to start from the beginning of the sentence
        output = new char[inputText.Length];        // set up the output to have the same number of letters as the input text, without printing those letters to the array just yet
        text.text = "";                             // make sure the text is clear
        cont.text = "";                             // make sure the continue text is clear

        timer = 0;                                  // set the timer so it will have no accumulated time to start
    }

    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E) && !talking && !ui.paused)     // when you aren't talking yet but E is pressed in range and the game isn't paused, do the following:
        {
            talking = true;                                         // - set the talking value to true
            player.talking = true;                                  // - set the player's talking value to true (makes the player unable to move, in this implementation
            audio.PlayOneShot(clip);                                // - play the talking audio (this will only play once, script must be changed if audio should play for each letter/sentence
            talkBox.gameObject.SetActive(true);                     // - allow the text box to be seen
            profile.SetActive(true);                                // - allow the profile picture of this creature to be seen
        }

        if (talking)                                                // so long as this character is talking, anything within this statement can/will occur
        {
            if (currentLetter <= inputText.Length)                  // as long as the last letter hasn't been reached, do the following:
            {                                                       // (this statement will occur each time that the current letter gets reset)
                for (int c = 0; c < currentLetter; c++)             // for every letter that exists in the letters array...
                {
                    output[c] = letters[c];                         // ...populate the value of the same position in the output array to match that letter
                }
            }
            else
            {
                cont.text = "Press E to continue";          // when you've reached the last letter, the continue text pops up

                if (Input.GetKeyDown(KeyCode.E) && !ui.paused)            // if E is pressed while the text is on the last letter...
                {
                    if(whichSentence < sentences.Length - 1)        // so long as you haven't reached the last sentence, do the following:
                    {
                        whichSentence++;                            // - increase which sentence is to be printed to the next sentence
                        currentLetter = 0;                          // - reset the current letter to the beginning (this allows the earlier for statement to r
                        inputText = sentences[whichSentence];       // - repopulate the input text to reflect the new sentence
                        Array.Clear(letters, 0, letters.Length);    // - clear the old letters from the letters array
                        Array.Clear(output, 0, output.Length);      // - clear the old letters from the output array
                        letters = inputText.ToCharArray();          // - repopulate the letters array to reflect the new sentence
                        output = new char[inputText.Length];        // - adjust the number of values in the output array, but don't populate yet
                        cont.text = "";                             // - clear the continue text
                    }
                    else
                    {                                               // when you have reached the end of the last sentence, do the following:
                        profile.SetActive(false);                   // - hide the profile picture
                        talkBox.SetActive(false);                   // - hide the talk box
                        currentLetter = 0;                          // - reset the current letter (you could also reset the sentance here, but for this implementation I want the last sentence to repeat if talking starts again)
                        talking = false;                            // - set talking value to false
                        player.talking = false;                     // - set the player's talking value to false
                        player.gameStarted = true;                  // - start the game, so the player can move
                        Array.Clear(output, 0, output.Length);      // - clear the output array (you would want to clear the input array as well if you are going to other sentences after this
                        cont.text = "";                             // - clear the continue text
                    }
                }
            }

            text.text = string.Join("", output);    // converts the output array into a string that can be printed in the text box

            timer += Time.deltaTime;    // update the timer each frame
            if (timer >= timeInterval && currentLetter <= inputText.Length)     // when the timer hits the time interval, so long as the letter last printed isn't the last in the sentence...
            {
                currentLetter++;       // ...update the letter that is to be printed...
                timer = 0;             // ...and reset the timer
            }
        }
    }
}