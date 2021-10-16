using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int currentSpeed;
    public int walkSpeed;
    public int runSpeed;
    public Rigidbody rbody;
    public float jumpHeight;
    public Animator animator;

    public bool isMoving;
    public bool isRunning;
    //public bool hasJumped;
    public bool isFalling;
    public float stamina;
    int staminaMax = 5;

    public bool grounded;
    public bool onDirt;

    public bool waving;
    public float waveTimer;

    public int candy;
    public bool hasGlue;

    Vector3 rotN = new Vector3(0.0f, 0.0f, 0.0f);
    Vector3 rotNE = new Vector3(0.0f, 45.0f, 0.0f);
    Vector3 rotE = new Vector3(0.0f, 90.0f, 0.0f);
    Vector3 rotSE = new Vector3(0.0f, 135.0f, 0.0f);
    Vector3 rotS = new Vector3(0.0f, 180.0f, 0.0f);
    Vector3 rotSW = new Vector3(0.0f, 225.0f, 0.0f);
    Vector3 rotW = new Vector3(0.0f, 270.0f, 0.0f);
    Vector3 rotNW = new Vector3(0.0f, 315.0f, 0.0f);

    void Start()
    {
        isFalling = false;
        stamina = staminaMax;

        grounded = true;
        onDirt = true;

        waveTimer = 0;

        candy = 0;
        hasGlue = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (rbody.velocity.y < Mathf.Abs(0.01f))
        {
            grounded = true;
            isFalling = false;
            if(collision.collider.name != "Plane")
            {
                onDirt = false;
            }
            else
            {
                onDirt = true;
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 tVel = Vector3.zero;
        float tempY = rbody.velocity.y;

        if (Input.GetKey(KeyCode.LeftShift) && isMoving && stamina != 0)
        {
            isRunning = true;
            currentSpeed = runSpeed;
            animator.SetBool("IsRunning", true);
        }
        else
        {
            isRunning = false;
            currentSpeed = walkSpeed;
            animator.SetBool("IsRunning", false);
        }

        if (waving)
        {
            animator.SetBool("Waving", true);
            waveTimer -= Time.deltaTime;
            if(waveTimer <= 0)
            {
                waveTimer = 0;
                waving = false;
            }
        }
        else
        {
            animator.SetBool("Waving", false);
            if (Input.GetKey(KeyCode.W))
            {
                tVel += transform.forward;
                isMoving = true;
                if (Input.GetKey(KeyCode.A))
                {
                    transform.rotation = Quaternion.Euler(rotNW);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    transform.rotation = Quaternion.Euler(rotNE);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(rotN);
                }
            }
            if (Input.GetKey(KeyCode.S))
            {
                tVel += transform.forward;
                isMoving = true;
                if (Input.GetKey(KeyCode.A))
                {
                    transform.rotation = Quaternion.Euler(rotSW);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    transform.rotation = Quaternion.Euler(rotSE);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(rotS);
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                isMoving = true;
                if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
                {
                    tVel += transform.forward;
                    transform.rotation = Quaternion.Euler(rotW);
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                isMoving = true;
                if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
                {
                    tVel += transform.forward;
                    transform.rotation = Quaternion.Euler(rotE);
                }
            }

            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
            {
                isMoving = false;
            }

            if (Input.GetKey(KeyCode.Space) && grounded)
            {
                isMoving = false;
                onDirt = false;
                rbody.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
                grounded = false;
            }

            if (isMoving)
            {
                animator.SetBool("IsWalking", true);
            }
            else
            {
                animator.SetBool("IsWalking", false);
            }

            if (rbody.velocity.y < 0)
            {
                isFalling = true;
            }

            tVel = tVel.normalized * currentSpeed;
            tVel.y = tempY;
            rbody.velocity = tVel;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && !isMoving && !waving)
        {
            waving = true;
            waveTimer = 2;
        }

        if (isRunning)
        {
            stamina -= Time.deltaTime;
            if(stamina < 0)
            {
                stamina = 0;
            }
        }
        else
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                stamina += Time.deltaTime;
                if(stamina > staminaMax)
                {
                    stamina = staminaMax;
                }
            }
        }
    }
}