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
                }
            }
            else
            {
                if (ghost.questStarted && !player.hasGlue)
                {
                    fireText.text = "Press E to make glue";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        player.hasGlue = true;
                    }
                }
                else
                {
                    fireText.text = "Press E to extinguish fire";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        fire.loop = false;
                        fireOn = false;
                    }
                }
            }
        }
    }
}
