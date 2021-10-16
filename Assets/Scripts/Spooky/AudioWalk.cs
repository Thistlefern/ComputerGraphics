using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioWalk : MonoBehaviour
{
    public PlayerController player;

    public AudioSource source;
    public AudioClip[] sounds = new AudioClip[4];
    float timeBetweenSteps;

    [SerializeField]
    float stepTimer;
    [SerializeField]
    bool audioPlaying;

    void Start()
    {
        source.clip = sounds[0];
        stepTimer = 0.0f;
        timeBetweenSteps = 0.5f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            stepTimer = 0.0f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            stepTimer = 0.0f;
        }

        if (audioPlaying)
        {
            stepTimer -= Time.deltaTime;

            if(stepTimer <= 0)
            {
                stepTimer = 0;
                audioPlaying = false;
            }
        }

        if (player.onDirt)
        {
            source.clip = sounds[0];
        }
        else
        {
            source.clip = sounds[2];
        }

        if (player.isRunning)
        {
            timeBetweenSteps = 0.333f;
        }
        else
        {
            timeBetweenSteps = 0.5f;
        }

        if (player.isMoving && !audioPlaying && player.grounded)
        {
            source.PlayOneShot(source.clip);
            stepTimer = timeBetweenSteps;
            audioPlaying = true;

            if (player.onDirt)
            {
                if(source.clip == sounds[0])
                {
                    source.clip = sounds[1];
                }
                else
                {
                    source.clip = sounds[0];
                }
            }
            else
            {
                if (source.clip == sounds[2])
                {
                    source.clip = sounds[3];
                }
                else
                {
                    source.clip = sounds[2];
                }
            }
        }
    }
}
