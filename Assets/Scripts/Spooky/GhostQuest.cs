using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostQuest : MonoBehaviour
{
    public PlayerController player;
    bool questStarted;
    public Text interact;
    bool inRange;

    private void OnTriggerEnter(Collider other)
    {
        inRange = true;
        interact.text = "Press E to interact";
    }

    private void OnTriggerExit(Collider other)
    {
        inRange = false;
        interact.text = "";
    }

    private void Start()
    {
        interact.text = "";
    }

    private void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Speak");
        }
    }
}
