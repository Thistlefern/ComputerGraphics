using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WillOWisp : MonoBehaviour
{
    public PlayerController player;
    public GameObject[] particles;

    public Text text;
    bool inRange;
    int number;

    private void Start()
    {
        text.text = "";
        inRange = false;
        number = 0;
        for(int i = 0; i < particles.Length; i++)
        {
            particles[i].SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        text.text = "Press E for help finding candy";
        inRange = true;
        Debug.Log(text.text);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Goodbye");
        text.text = "";
        inRange = false;
    }

    private void Update()
    {
        if(number < player.candy)
        {
            particles[number].SetActive(false);
            number = player.candy;
        }

        if(Input.GetKeyDown(KeyCode.E) && inRange)
        {
            particles[number].SetActive(true);
        }
    }
}
