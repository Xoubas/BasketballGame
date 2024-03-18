using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    void Update()
    {
        //Carga la escena si pulsas una tecla
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("MainScene");
        }
    }


}
