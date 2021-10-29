using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostQuest : MonoBehaviour
{
    public PlayerController player;
    public bool questStarted;
    public bool headstoneFixed;
    public Text interact;
    public bool inRange;
    public Animator animator;
    public new AudioSource audio;
    public AudioClip clip;

    public GameObject brokenStone;
    public GameObject fixedStone;

    public string[] sentences = new string[3];

    public GameObject talkBox;
    public bool talking;
    public GameObject profile;

    string interactText;

    private void OnTriggerEnter(Collider other)
    {
        inRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inRange = false;
        interact.text = "";
    }

    private void Start()
    {
        questStarted = false;
        headstoneFixed = false;

        interact.text = "";

        sentences[0] = "Boo hoo...some kids knocked over my headstone, and now I can't go back to sleep...";
        sentences[1] = "Could you please help me? If you got some glue, my headstone could be fixed!";
        sentences[2] = "Thank you so much! Time for a nap. Here, take this for your troubles!";
        
        profile.SetActive(false);
        talkBox.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (player.hasGlue)
        {
            interactText = "Press E to fix headstone";
        }
        else
        {
            interactText = "Press E to interact";
        }

        if (inRange)
        {
            interact.text = interactText;
        }

        if(inRange && Input.GetKeyDown(KeyCode.E) && !talking)
        {
            if (!player.hasGlue)
            {
                talking = true;
                audio.PlayOneShot(clip);
                player.talking = true;
                talkBox.gameObject.SetActive(true);
                profile.SetActive(true);
            }
            else
            {
                brokenStone.SetActive(false);
                fixedStone.SetActive(true);
                // TODO tombstone fixed sound here
                headstoneFixed = true;
                player.hasGlue = false;
            }
        }
    }
}
