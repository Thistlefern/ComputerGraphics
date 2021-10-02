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
    public bool hasJumped;
    public bool isFalling;

    public bool waving;
    public float waveTimer;

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
        hasJumped = false;
        isFalling = false;
        waveTimer = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    void FixedUpdate()
    {
        Vector3 tVel = Vector3.zero;
        float tempY = rbody.velocity.y;

        if (Input.GetKey(KeyCode.LeftShift) && isMoving)
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

        if (Input.GetKeyDown(KeyCode.G) && !isMoving)
        {
            waving = true;
            waveTimer = 2;
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
                // transform.position += transform.forward * currentSpeed * Time.fixedDeltaTime;
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
                // transform.position += transform.forward * currentSpeed * Time.fixedDeltaTime;
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
                    // transform.position += transform.forward * currentSpeed * Time.fixedDeltaTime;
                    tVel += transform.forward;
                    transform.rotation = Quaternion.Euler(rotW);
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                isMoving = true;
                if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
                {
                    // transform.position += transform.forward * currentSpeed * Time.fixedDeltaTime;
                    tVel += transform.forward;
                    transform.rotation = Quaternion.Euler(rotE);
                }
            }

            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
            {
                isMoving = false;
            }

            if (Input.GetKey(KeyCode.Space) && !hasJumped)
            {
                isMoving = false;
                rbody.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
                hasJumped = true;
                // animator.SetBool("HasJumped", true);
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

            if (rbody.velocity.y == 0 && isFalling)
            {
                hasJumped = false;
                // animator.SetBool("HasJumped", false);
                isFalling = false;
            }

            tVel = tVel.normalized * currentSpeed;

            tVel.y = tempY;
            rbody.velocity = tVel;
        }
    }
}