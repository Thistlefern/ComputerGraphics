using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    public Text fireText;
    public bool fireOn;
    public GameObject fire;
    public bool inRange;

    private void OnTriggerEnter(Collider other)
    {
        inRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        fireText.text = "";
        inRange = false;
    }

    void Start()
    {
        fireText.text = "";
        fireOn = false;
        fire.SetActive(false);
        inRange = false;
    }

    private void Update()
    {
        if (inRange)
        {
            if (!fireOn)
            {
                fireText.text = "Press E to light fire";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    fire.SetActive(true);
                    fireOn = true;
                }
            }
            else
            {
                fireText.text = "Press E to extinguish fire";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    fire.SetActive(false);
                    fireOn = false;
                }
            }
        }
    }
}
