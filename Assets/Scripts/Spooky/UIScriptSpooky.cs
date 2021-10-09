using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScriptSpooky : MonoBehaviour
{
    public PlayerController player;

    public Text candyToFind;
    int candyTotal;

    public Slider staminaSlider;

    void Start()
    {
        candyTotal = 5;
    }

    void Update()
    {
        candyToFind.text = "Candy Left: " + Mathf.CeilToInt(candyTotal - player.candy).ToString();
        staminaSlider.value = player.stamina;
    }
}
