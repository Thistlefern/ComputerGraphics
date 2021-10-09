using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WrongWay : MonoBehaviour
{
    public Text wrongWayText;

    private void OnTriggerEnter(Collider other)
    {
        //text.gameObject.SetActive(true);
        wrongWayText.text = "I can't go this way!";
    }

    private void OnTriggerExit(Collider other)
    {
        wrongWayText.text = "";
    }

    void Start()
    {
        //text.gameObject.SetActive(false);
    }
}
