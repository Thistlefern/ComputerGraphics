using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LetterByLetter : MonoBehaviour
{
    public string inputText;
    public char[] letters;
    public char[] output;
    public int currentLetter;
    public Text text;
    public Text cont;

    float timer;
    public float timeInterval;

    public int whichSentence;
    public GhostQuest ghost;
    public GameObject actualGhost;
    public PlayerController player;
    public GameObject cookie;
    public bool cookieDestroyed;

    public float goodbyeTimer = 2;

    void Start()
    {
        whichSentence = 0;
        inputText = ghost.sentences[whichSentence];
        
        letters = inputText.ToCharArray();
        output = new char[inputText.Length];
        currentLetter = 1;
        text.text = "";
        cont.text = "";
        
        timer = 0;

        cookie.SetActive(false);
    }

    void Update()
    {
        if (!ghost.questStarted && ghost.headstoneFixed && goodbyeTimer > 0 && !cookieDestroyed)
        {
            cookie.SetActive(true);
            goodbyeTimer -= Time.deltaTime;
            if(goodbyeTimer <= 0)
            {
                actualGhost.SetActive(false);
            }
        }

        if (ghost.headstoneFixed && ghost.questStarted)
        {
            whichSentence = 2;
            inputText = ghost.sentences[whichSentence];
            letters = inputText.ToCharArray();
        }

        if (ghost.talking)
        {
            if(currentLetter <= inputText.Length)
            {
                for(int c = 0; c < currentLetter; c++)
                {
                    output[c] = letters[c];
                }
            }

            if(currentLetter > inputText.Length)
            {
                cont.text = "Press E to continue";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if(whichSentence == 0 && !player.hasGlue)
                    {
                        whichSentence = 1;
                        currentLetter = 0;
                        inputText = ghost.sentences[whichSentence];
                        Array.Clear(letters, 0, letters.Length);
                        Array.Clear(output, 0, output.Length);
                        letters = inputText.ToCharArray();
                        cont.text = "";
                    }
                    else
                    {
                        if (!ghost.headstoneFixed)
                        {
                            ghost.talkBox.SetActive(false);
                            ghost.talking = false;
                            player.ghostTalking = false;
                            whichSentence = 0;
                            currentLetter = 0;
                            inputText = ghost.sentences[whichSentence];
                            Array.Clear(letters, 0, letters.Length);
                            Array.Clear(output, 0, output.Length);
                            letters = inputText.ToCharArray();
                            cont.text = "";
                            ghost.questStarted = true;
                        }
                        else
                        {
                            ghost.questStarted = false;
                            ghost.talkBox.SetActive(false);
                            ghost.talking = false;
                            player.ghostTalking = false;
                            ghost.animator.SetBool("Goodbye", true);
                            ghost.inRange = false;
                            ghost.interact.text = "";
                        }
                    }
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
