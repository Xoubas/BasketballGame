using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int pointsA;
    private int pointsB;

    public Text playerAScore;
    public Text playerBScore;

    //Añadir puntos jugador A
    public void addPointA()
    {
        pointsA++;
        playerAScore.text = pointsA.ToString();
        CheckForWinner();
    }
    //Añadir puntos jugador B
    public void addPointB()
    {
        pointsB++;
        playerBScore.text = pointsB.ToString();
        CheckForWinner();
    }

    void CheckForWinner()
    {
        if (pointsA >= 7 || pointsB >= 7)
        {
            // Carga la escena MainMenu
            SceneManager.LoadScene("MainMenu");
        }
    }
}
