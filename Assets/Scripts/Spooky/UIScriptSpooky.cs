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

    public bool paused;

    public GameObject pauseMenu;

    public GameObject actualPause;
    public GameObject areYouSure;
    public Button menu;
    public Button exit;

    public new AudioSource audio;
    public AudioClip clip;

    public GameObject glueIcon;

    void Start()
    {
        candyTotal = 5;
        paused = false;
        pauseMenu.SetActive(false);

        menu.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
    }

    void Update()
    {
        candyToFind.text = "Candy Left: " + Mathf.CeilToInt(candyTotal - player.candy).ToString();
        staminaSlider.value = player.stamina;

        if (player.hasGlue)
        {
            glueIcon.SetActive(true);
        }
        else
        {
            glueIcon.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                paused = true;
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                actualPause.SetActive(true);
            }
            else
            {
                paused = false;
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                areYouSure.SetActive(false);
            }
        }
    }

    public void UnPause()
    {
        paused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        areYouSure.SetActive(false);

        menu.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void AreYouSure(bool toMenu)
    {
        actualPause.SetActive(false);
        areYouSure.SetActive(true);

        if (toMenu)
        {
            menu.gameObject.SetActive(true);
        }
        else
        {
            exit.gameObject.SetActive(true);
        }
    }

    public void ButtonHover()
    {
        audio.PlayOneShot(clip);
    }
}