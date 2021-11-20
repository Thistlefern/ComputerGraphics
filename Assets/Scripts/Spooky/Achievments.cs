using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievments : MonoBehaviour
{
    // ideas:
    // you're no help: ask for no help
    // hint hound: ask for hints x number of times
    // will-o-wisp friend: get help from the wisps to find all pieces of candy
    // time challenge: find all the candies in x amount of time or less
    // wanderlust: try and leave the boneyard x number of times

    public GameObject toHide;
    public GameObject toShow;
    public PlayerController player;
    public PumpkinNice pumpkin;
    public WillOWisp wisps;
    public WrongWay gate;

    // checks if a helpless run has been completed, for the YOU'RE NO HELP achievement
    static bool helpDenied;
    static bool tempHelpDenied;    // resets each round, so that the real one won't change
    public GameObject bonesHelp;
    public GameObject trophyHelp;

    // checks how many hints have been asked for, for the HINT HOUND achievement
    static bool multipleHints;
    public GameObject bonesHint;
    public GameObject trophyHint;

    // checks which candies the wisps lead you to, for the WISPERS IN THE DARK achievement
    public bool wispFriend;
    public GameObject bonesWisps;
    public GameObject trophyWisps;

    // checks if the player has ever beaten the time challenege, for the TIME CHALLENGE achievement
    static bool timeChallenge;
    public GameObject bonesTime;
    public GameObject trophyTime;

    // checks if the player attempted to leave a lot, for the WANDERLUST achievement
    static bool awolAttempted;
    public GameObject bonesLeave;
    public GameObject trophyLeave;

    void Start()
    {
        toHide.SetActive(true);
        toShow.SetActive(false);

        tempHelpDenied = true;
        timeChallenge = true;
    }

    void Update()
    {
        if (player.helpAsked)
        {
            tempHelpDenied = false;
        }
        if(player.candy == 5 && tempHelpDenied)
        {
            helpDenied = true;
        }

        if(pumpkin.numberOfHints >= 4)
        {
            multipleHints = true;
        }

        if (wisps.allCandyAsked)
        {
            wispFriend = true;
        }

        if(player.timer <= 60)
        {
            timeChallenge = false;
        }

        if(gate.hitCount >= 10)
        {
            awolAttempted = true;
        }
    }

    public void ShowAchievements()
    {
        Debug.Log("test");
        toHide.SetActive(false);
        toShow.SetActive(true);

        if (helpDenied)
        {
            bonesHelp.SetActive(false);
            trophyHelp.SetActive(true);
        }
        else
        {
            bonesHelp.SetActive(true);
            trophyHelp.SetActive(false);
        }

        if (multipleHints)
        {
            bonesHint.SetActive(false);
            trophyHint.SetActive(true);
        }
        else
        {
            bonesHint.SetActive(true);
            trophyHint.SetActive(false);
        }

        if (wispFriend)
        {
            bonesWisps.SetActive(false);
            trophyWisps.SetActive(true);
        }
        else
        {
            bonesWisps.SetActive(true);
            trophyWisps.SetActive(false);
        }

        if (timeChallenge)
        {
            bonesTime.SetActive(false);
            trophyTime.SetActive(true);
        }
        else
        {
            bonesTime.SetActive(true);
            trophyTime.SetActive(false);
        }

        if (awolAttempted)
        {
            bonesLeave.SetActive(false);
            trophyLeave.SetActive(true);
        }
        else
        {
            bonesLeave.SetActive(true);
            trophyLeave.SetActive(false);
        }
    }

    public void HideAchievements()
    {
        toHide.SetActive(true);
        toShow.SetActive(false);
    }
}
