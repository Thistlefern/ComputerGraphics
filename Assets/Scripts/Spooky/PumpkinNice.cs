using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PumpkinNice : MonoBehaviour
{
    bool inRange;           // checks if player is in range
    string interactText;    // the text which shows when the player is in range
    public Text interact;   // the object that holds the interectText

    string[] sentences;         // array that holds the sentences
    public int whichSentence;   // number which determines which sentence from the array is the current focus
    
    public GameObject talkBox;
    string inputText;   // grabs a sentence from the sentences array per the whichSentence number
    char[] letters;     // takes the sentence above, one letter at a time
    char[] output;      // will populate with the stored sentence as time goes on
    int currentLetter;  // keeps track of where in the stored sentence needs to be printed to output next
    float timer;        // keeps track of the time since the last letter was printed
    public float timeInterval;  // the time between letters being printed
    public Text text;   // the object that prints the output
    public Text cont;   // the object that prints the text to continue once the sentence has been fuly printed

    public new AudioSource audio;   // audio source for the sound of talking
    public AudioClip clip;          // clip of talking
    bool talking;                   // checks if the character is currently talking

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
        currentLetter = 0;

        sentences[0] = "";
        sentences[1] = "";
    }

    void Update()
    {
        if (inRange)
        {
            interact.text = "Press E to interact";
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("the thing");
            }
        }
    }
}