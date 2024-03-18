using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchController : MonoBehaviour
{
    public float launchForce = 10f;
    private GameObject currentBall;
    private bool hasBall = false;
    private float distanceFromPlayer = 1.0f;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    //Cuando tenga la pelota el jugador podrá lanzarla
    void Update()
    {
        if (hasBall && Input.GetKeyDown(KeyCode.RightControl)) // Lanza la pelota con la tecla J
        {
            ShootBall();
        }
    }

    public void PickUpBall(GameObject ball)
    {
        if (!hasBall)
        {
            currentBall = ball;
            hasBall = true;
            ball.SetActive(false);
        }
    }

    /*El método shootball calcula mediante local scale hacia donde está mirando el jugador 
    a partir de ahí el juego hace que la pelota vuelva a estar activa y la lanza en la dirección indicada en el vector*/
    void ShootBall()
    {
        if (currentBall != null)
        { //Desvincula la pelota del jugador
            currentBall.SetActive(true);

            //Donde se lanza la pelota segun hacia donde en x este mirando el jugador
            Vector3 launchDirection;
            if (transform.localScale.x > 0)
            {
                //Derecha
                launchDirection = new Vector3(-1, 1, 0);
            }
            else
            {
                //Izquierda
                launchDirection = new Vector3(1, 1, 0);
            }

            //Posiciona la pelota delante del jugador s
            Vector3 launchPosition = transform.position + launchDirection * distanceFromPlayer;
            currentBall.transform.position = launchPosition;

            Rigidbody ballRigidbody = currentBall.GetComponent<Rigidbody>();
            ballRigidbody.isKinematic = false;
            ballRigidbody.velocity = Vector3.zero;

            //Aplica fuerza a la pelota
            ballRigidbody.AddForce(launchDirection.normalized * launchForce, ForceMode.VelocityChange);

            //Cambia parametros de la animacion
            animator.SetBool("HoldingBall", false);
            animator.SetLayerWeight(1, 0);
            hasBall = false;
            currentBall = null;
        }
    }




    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball" && !hasBall)
        {
            PickUpBall(collision.gameObject);
        }
    }
}
