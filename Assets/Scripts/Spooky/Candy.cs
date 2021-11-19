using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    public PlayerController player;
    public new AudioSource audio;
    public AudioClip clip;
    public LetterByLetter ghostWords;
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        audio.PlayOneShot(clip);
        player.candy++;
        if(transform.name == "Cookie")
        {
            ghostWords.cookieDestroyed = true;
        }
        Destroy(gameObject);
    }
}