using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Animator animator;
    private Rigidbody body;
    private bool onGround;

    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = 0;

        
        /*Básicamente añade movimiento al jugador en una dirección segun la flecha que se pulse*/
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveHorizontal = 1; 
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveHorizontal = -1;
        }

        body.velocity = new Vector3(moveHorizontal * speed, body.velocity.y, 0);

        animator.SetBool("Moving", moveHorizontal != 0);

        if (moveHorizontal > 0)
        {
            transform.localScale = new Vector3(-5, 5, 1); //Derecha
        }
        else if (moveHorizontal < 0)
        {
            transform.localScale = new Vector3(5, 5, 1); //Izquierda
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && onGround)
        {
            body.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            animator.SetBool("Jumping", true);
            onGround = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetBool("Jumping", false);
            onGround = true;
        }
    }
}
