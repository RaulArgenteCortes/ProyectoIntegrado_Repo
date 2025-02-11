using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    // Referencias a los botones
    [Header("Botones de MainMenu")]
    public Button button_PauseMenu_Continue;
    public Button button_PauseMenu_MainMenu;


    [Header("Pause Parameters")]
    public GameObject panel_PauseMenu;
    [SerializeField] bool isGamePaused;

    void Start()
    {
        // Asigna las funciones de los botones.
        button_PauseMenu_Continue.onClick.AddListener(OpenPauseMenu);
        button_PauseMenu_MainMenu.onClick.AddListener(LoadMainMenu);

        // Fijación de variables
        isGamePaused = false;

        // Desactiva el panel
        panel_PauseMenu.SetActive(false);
    }

    public void OpenPauseMenu()
    {
        if (isGamePaused == false)
        {
            panel_PauseMenu.SetActive(true);
            Time.timeScale = 0;
            isGamePaused = true;
        }
        else
        {
            panel_PauseMenu.SetActive(false);
            Time.timeScale = 1;
            isGamePaused = false;
        }
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}