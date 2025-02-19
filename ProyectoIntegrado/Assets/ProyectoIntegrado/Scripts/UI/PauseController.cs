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

    [Header("External Scripts")]
    [SerializeField] AudioManager Script_AudioManager;

    void Start()
    {
        // Asigna las funciones de los botones.
        button_PauseMenu_Continue.onClick.AddListener(OpenPauseMenu);
        button_PauseMenu_MainMenu.onClick.AddListener(LoadMainMenu);

        // Fijación de variables
        isGamePaused = false;
        Time.timeScale = 1;

        // Desactiva el panel
        panel_PauseMenu.SetActive(false);

        // Referencias a otros scripts
        Script_AudioManager = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();
    }

    public void OpenPauseMenu()
    {
        Script_AudioManager.PlaySfx(Script_AudioManager.buttonPress);

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
        Script_AudioManager.PlaySfx(Script_AudioManager.buttonPress);
        Time.timeScale = 1;
        isGamePaused = false;
        SceneManager.LoadScene("MainMenu");
    }
}