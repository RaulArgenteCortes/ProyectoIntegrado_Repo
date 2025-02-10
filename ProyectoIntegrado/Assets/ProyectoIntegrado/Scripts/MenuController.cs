using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    // Referencias a los botones
    public Button playButton;
    public Button quitButton;

    void Start()
    {
        // Asignar las funciones a los botones
        playButton.onClick.AddListener(OnPlayButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);
       
    }

    // Función para iniciar el juego
    void OnPlayButtonClicked()
    {
        Debug.Log("Iniciar juego...");
        // Cargar la escena del juego (cambia "GameScene" por el nombre de tu escena)
        SceneManager.LoadScene("Level_01");
    }

    // Función para salir del juego
    void OnQuitButtonClicked()
    {
        Debug.Log("Salir del juego...");
        Application.Quit();
    }
}
       
    