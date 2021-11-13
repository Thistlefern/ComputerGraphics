using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PumpkinNice : MonoBehaviour
{
    bool inRange;           // checks if player is in range
    string interactText;    // the text which shows when the player is in range
    public Text interact;   // the object that holds the interectText

    // TODO add hints and adjust number of sentences in array
    string[] sentences = new string[5]; // array that holds the sentences, adjust this number to match number of sentences
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

    public GhostQuest ghost;
    bool clues2;

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
        #region sentences
        sentences[0] = "Happy Halloween! Need some hints? Well you're in luck, they're my specialty!";
        sentences[1] = "The candies you need to find are hidden all around the boneyard, some pieces better than others.";
        sentences[2] = "Keep an eye out for shadows, as sometimes this is the easiest way to spot a candy.";
        sentences[3] = "You'll probably even have to jump on top of things to get some candies!";
        sentences[4] = "There's a headstone nearby that has will-o-wisps hanging out around it. They can help lead you to candy!";
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
        if (clues2)
        {
            sentences[0] = "Happy Halloween! Need some hints? Well you're in luck, they're my specialty!";
            sentences[1] = "Oh! It seems that you need to get some glue for that friendly ghost.";
            sentences[2] = "To make some glue, you'll just need a fire and a bone.";
            sentences[3] = "There's a fire basket on top of the pillar at the center of the cemetary.";
            sentences[4] = "And I'm sure you've got a rib you can spare! Get it? Spare rib? Haha!";
        }
        else
        {
            sentences[0] = "Happy Halloween! Need some hints? Well you're in luck, they're my specialty!";
            sentences[1] = "The candies you need to find are hidden all around the boneyard, some pieces better than others.";
            sentences[2] = "Keep an eye out for shadows, as sometimes this is the easiest way to spot a candy.";
            sentences[3] = "You'll probably even have to jump on top of things to get some candies!";
            sentences[4] = "There's a headstone nearby that has will-o-wisps hanging out around it. They can help lead you to candy!";
        }

        if (inRange && Input.GetKeyDown(KeyCode.E) && !talking)     // when you aren't talking yet but E is pressed in range, do the following:
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

                if (Input.GetKeyDown(KeyCode.E))            // if E is pressed while the text is on the last letter...
                {
                    if (whichSentence < sentences.Length - 1)        // so long as you haven't reached the last sentence, do the following:
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
                        whichSentence = 0;                          // - reset the current sentence
                        currentLetter = 0;                          // - reset the current letter
                        inputText = sentences[whichSentence];       // - repopulate the input text to reflect the new sentence
                        talking = false;                            // - set talking value to false
                        player.talking = false;                     // - set the player's talking value to false
                        player.gameStarted = true;                  // - start the game, so the player can move
                        Array.Clear(letters, 0, letters.Length);    // - clear the old letters from the letters array
                        Array.Clear(output, 0, output.Length);      // - clear the output array (you would want to clear the input array as well if you are going to other sentences after this
                        letters = inputText.ToCharArray();          // - repopulate the letters array to reflect the new sentence
                        output = new char[inputText.Length];        // - adjust the number of values in the output array, but don't populate yet
                        cont.text = "";                             // - clear the continue text

                        if (ghost.questStarted)
                        {
                            if (!clues2)
                            {
                                clues2 = true;
                            }
                            else
                            {
                                clues2 = false;
                            }
                        }
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