using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFade : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Animator animator;
    bool dead;
    float lilTimer;

    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        lilTimer = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            dead = true;
            animator.SetTrigger("Death");
        }
        if (dead)
        {
            lilTimer -= Time.deltaTime;
            if(lilTimer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
