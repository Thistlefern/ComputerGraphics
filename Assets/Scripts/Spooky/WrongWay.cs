using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WrongWay : MonoBehaviour
{
    public Text wrongWayText;
    public int hitCount;


    private void Start()
    {
        hitCount = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        wrongWayText.text = "I can't go this way!";
        hitCount++;
    }

    private void OnTriggerExit(Collider other)
    {
        wrongWayText.text = "";
    }
}
