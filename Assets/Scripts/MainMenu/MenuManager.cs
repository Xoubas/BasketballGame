using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Hace que este objeto persista a través de cambios de escena
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // Destruye este objeto si ya existe un GameManager
        }
    }
}
