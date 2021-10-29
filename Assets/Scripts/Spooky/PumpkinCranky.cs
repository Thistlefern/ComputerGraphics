using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PumpkinCranky : MonoBehaviour
{
    bool inRange;           // checks if player is in range
    string interactText;    // the text which shows when the player is in range
    public Text interact;   // the object that holds the interectText

    string[] sentences = new string[6]; // array that holds the sentences
    public int whichSentence;           // number which determines which sentence from the array is the current focus

    public GameObject talkBox;
    public GameObject profile;
    string inputText;           // grabs a sentence from the sentences array per the whichSentence number
    public char[] letters;      // takes the sentence above, one letter at a time
    public char[] output;       // will populate with the stored sentence as time goes on
    public int currentLetter;          // keeps track of where in the stored sentence needs to be printed to output next
    float timer;                // keeps track of the time since the last letter was printed
    public float timeInterval;  // the time between letters being printed
    public Text text;           // the object that prints the output
    public Text cont;           // the object that prints the text to continue once the sentence has been fuly printed

    public new AudioSource audio;   // audio source for the sound of talking
    public AudioClip clip;          // clip of talking
    bool talking;                   // checks if the character is currently talking

    public PlayerController player;

    private void OnTriggerEnter(Collider other)
    {
        inRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        inRange = false;
        interact.text = "";
    }

    void Start()
    {
        interact.text = "";

        #region sentences
        sentences[0] = "Happy All Hallows Eve, bud.";
        sentences[1] = "A bunch of teenagers got scared off when you woke up.";
        sentences[2] = "It was pretty funny to watch, honestly.";
        sentences[3] = "But, as usual, teenagers can't exist without making a mess, can they?";
        sentences[4] = "Mind cleaning up the candy they left behind? It really kills the creepy vibe.";
        sentences[5] = "Use WASD to move, and Space to jump. Ask my brother up on that headstone for hints if you need them.";
        #endregion

        whichSentence = 0;
        inputText = sentences[whichSentence];

        currentLetter = 1;
        letters = inputText.ToCharArray();
        output = new char[inputText.Length];
        text.text = "";
        cont.text = "";

        timer = 0;
    }

    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E) && !talking)
        {
            talking = true;
            audio.PlayOneShot(clip);
            player.talking = true;
            talkBox.gameObject.SetActive(true);
            profile.SetActive(true);
        }

        if (talking)
        {
            if (currentLetter <= inputText.Length)
            {
                for (int c = 0; c < currentLetter; c++)
                {
                    output[c] = letters[c];
                }
            }

            if (currentLetter > inputText.Length)
            {
                cont.text = "Press E to continue";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("continue");
                    //if (whichSentence == 0 && !player.hasGlue)
                    //{
                    //    whichSentence = 1;
                    //    currentLetter = 0;
                    //    inputText = ghost.sentences[whichSentence];
                    //    Array.Clear(letters, 0, letters.Length);
                    //    Array.Clear(output, 0, output.Length);
                    //    letters = inputText.ToCharArray();
                    //    cont.text = "";
                    //}
                    //else
                    //{
                    //    if (!ghost.headstoneFixed)
                    //    {
                    //        ghost.profile.SetActive(false);
                    //        ghost.talkBox.SetActive(false);
                    //        ghost.talking = false;
                    //        player.talking = false;
                    //        whichSentence = 0;
                    //        currentLetter = 0;
                    //        inputText = ghost.sentences[whichSentence];
                    //        Array.Clear(letters, 0, letters.Length);
                    //        Array.Clear(output, 0, output.Length);
                    //        letters = inputText.ToCharArray();
                    //        cont.text = "";
                    //        ghost.questStarted = true;
                    //    }
                    //    else
                    //    {
                    //        ghost.questStarted = false;
                    //        ghost.talkBox.SetActive(false);
                    //        ghost.profile.SetActive(false);
                    //        ghost.talking = false;
                    //        player.talking = false;
                    //        ghost.animator.SetBool("Goodbye", true);
                    //        ghost.inRange = false;
                    //        ghost.interact.text = "";
                    //    }
                    //}
                }
            }

            text.text = string.Join("", output);

            timer += Time.deltaTime;
            if (timer >= timeInterval && currentLetter <= inputText.Length)
            {
                currentLetter++;
                timer = 0;
            }
        }
    }
}