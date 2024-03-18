using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameManager gameManager;
    private AudioSource audioSource;
    private Vector3 startPosition = new Vector3(0, 2, 0.15f); // Posición inicial de la pelota

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Initiate();
    }

    // Update is called once per frame
    void Update()
    {
        //Si la sale del campo y cae por debajo de y=-100 sereinicia la pelota
        if (transform.position.y < -30)
        {
            //Reinicia la posición de la pelota y espera antes de caer nuevamente
            Initiate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CubeLeft")
        {
            //Encesta en la izquierda
            gameManager.addPointA();
        }
        else if (other.tag == "CubeRight")
        {
            //Encesta en la derecha
            gameManager.addPointB();
        }
    }

    //Recoloca la pelota en el centro del campo cuando sale o al iniciar el juego
    void Initiate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.position = startPosition;
        
        //Desactiva temporalmente la física de la pelota
        rb.isKinematic = true;

        //Detiene todas las corutinas
        StopAllCoroutines();

        //Inicia la corutina para lanzar la pelota después de 2 segundos
        StartCoroutine(LaunchBallDelay(2));
        audioSource.Play();
    }

    IEnumerator LaunchBallDelay(float segundos)
    {
        //Espera segundos especificados
        yield return new WaitForSeconds(segundos);
        
        //Activa el rigidbody para que caiga la pelota
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
