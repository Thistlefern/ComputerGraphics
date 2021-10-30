using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WillOWisp : MonoBehaviour
{
    public PlayerController player;
    public GameObject[] particles;

    public Text text;
    bool inRange;
    int candyFound;
    int whichCandy;

    public GameObject candy0;
    public GameObject candy1;
    public GameObject candy2;
    public GameObject candy3;
    public GameObject candy4;

    private void Start()
    {
        text.text = "";
        inRange = false;
        candyFound = 0;
        whichCandy = 0;
        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        text.text = "Press E for help finding candy";
        inRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        text.text = "";
        inRange = false;
    }

    private void Update()
    {
        if (candyFound < player.candy)
        {
            particles[whichCandy].SetActive(false);
            candyFound = player.candy;
        }

        if (candy0 == null && whichCandy == 0)
        {
            whichCandy++;
        }
        if(candy1 == null && whichCandy == 1)
        {
            whichCandy++;
        }
        if (candy2 == null && whichCandy == 2)
        {
            whichCandy++;
        }
        if (candy3 == null && whichCandy == 3)
        {
            whichCandy++;
        }
        if (candy4 == null && whichCandy == 4)
        {
            whichCandy++;
        }

        // when the player gets a candy, check the candy's name
        // clear the spot in the array that holds that candy
        // when checking which candy to show the way to, if the spot in the array is null, move on

        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            particles[whichCandy].SetActive(true);
            //if (particles[number] == null)
            //{
            //    number++;
            //}
            //else
            //{
            //    particles[number].SetActive(true);
            //}
        }
    }
}
