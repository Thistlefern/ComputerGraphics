using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Text text;
    public float speed;
    bool scrolling;
    float height;
    public float minHeight;
    public float maxHeight;
    public Animator animator;
    public new AudioSource audio;
    public AudioClip hoverClip;
    public AudioClip clickClip;

    void Update()
    {
        if (scrolling)
        {
            height += Time.deltaTime * speed;
            text.rectTransform.position = new Vector3(960, height, 0);
            if (height >= maxHeight)
            {
                scrolling = false;
                animator.SetBool("Scrolling", false);
            }
        }
    }

    public void ChangeScene(string sceneName)
    {
        if (!scrolling)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void Scroll()
    {
        if (!scrolling)
        {
            text.rectTransform.position = new Vector3(960, minHeight, 0);
            height = minHeight;
            scrolling = true;
            animator.SetBool("Scrolling", true);
        }
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void ButtonHover()
    {
        audio.PlayOneShot(hoverClip);
    }
    public void ButtonClick()
    {
        audio.PlayOneShot(clickClip);
    }
}