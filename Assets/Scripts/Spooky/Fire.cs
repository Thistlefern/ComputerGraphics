using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    public Text fireText;
    public bool fireOn;
    public ParticleSystem fire;
    public bool inRange;
    public GhostQuest ghost;
    public PlayerController player;

    public new AudioSource audio;
    public AudioClip glueSound;

    private void OnTriggerEnter(Collider other)
    {
        inRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        fireText.text = "";
        inRange = false;
    }

    [System.Obsolete]
    void Start()
    {
        fireText.text = "";
        fireOn = false;
        fire.loop = false;
        inRange = false;
        audio.mute = true;
    }

    [System.Obsolete]
    private void Update()
    {
        if (inRange)
        {
            if (!fireOn)
            {
                fireText.text = "Press E to light fire";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    fire.loop = true;
                    fire.Play();
                    fireOn = true;
                    audio.mute = false;
                }
            }
            else
            {
                if (!fire.isPlaying)
                {
                    fire.Play();
                }
                if (ghost.questStarted && !player.hasGlue)
                {
                    fireText.text = "Press E to make glue";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        player.hasGlue = true;
                        audio.PlayOneShot(glueSound);
                    }
                }
                else
                {
                    fireText.text = "Press E to extinguish fire";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        fire.loop = false;
                        fireOn = false;
                        audio.mute = true;
                    }
                }
            }
        }
    }
}