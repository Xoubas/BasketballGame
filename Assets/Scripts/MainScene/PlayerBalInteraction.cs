using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallInteraction : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("Cambiando a HoldingBall true y ajustando el peso de la capa Balling");
            animator.SetBool("HoldingBall", true);
            animator.SetLayerWeight(1, 1);
        }
    }
}
