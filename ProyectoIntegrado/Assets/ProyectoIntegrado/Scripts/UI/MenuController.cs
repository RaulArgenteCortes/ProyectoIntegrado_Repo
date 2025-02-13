using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    // Referencias a los botones
    [Header("Botones de MainMenu")]
    public Button button_MainMenu_Levels;
    public Button button_MainMenu_Help;
    public Button button_MainMenu_Exit;

    [Header("Botones de Levels")]
    public Button button_Levels_Back;

    [Header("Botones de Help")]
    public Button button_Help_Back;

    [Header("Paneles")]
    public GameObject panel_MainMenu;
    public GameObject panel_Levels;
    public GameObject panel_Help;

    [Header("External Scripts")]
    [SerializeField] AudioManager Script_AudioManager;

    void Start()
    {
        // Asigna las funciones de los botones.

        button_MainMenu_Levels.onClick.AddListener(OpenLevels);
        button_MainMenu_Help.onClick.AddListener(OpenHelp);
        button_MainMenu_Exit.onClick.AddListener(CloseGame);

        button_Levels_Back.onClick.AddListener(OpenMainMenu);

        button_Help_Back.onClick.AddListener(OpenMainMenu);


        // Desactiva todos los paneles excepto MainMenu.
        panel_MainMenu.SetActive(true);
        panel_Levels.SetActive(false);
        panel_Help.SetActive(false);

        // Referencias a otros scripts
        Script_AudioManager = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();
    }

    void OpenMainMenu()
    {
        panel_MainMenu.SetActive(true);
        panel_Levels.SetActive(false);
        panel_Help.SetActive(false);

        Script_AudioManager.PlaySfx(Script_AudioManager.buttonPress);
    }

    void OpenLevels()
    {
        panel_MainMenu.SetActive(false);
        panel_Levels.SetActive(true);
        panel_Help.SetActive(false);

        Script_AudioManager.PlaySfx(Script_AudioManager.buttonPress);
    }

    void OpenHelp()
    {
        panel_MainMenu.SetActive(false);
        panel_Levels.SetActive(false);
        panel_Help.SetActive(true);

        Script_AudioManager.PlaySfx(Script_AudioManager.buttonPress);
    }

    void CloseGame()
    {
        Script_AudioManager.PlaySfx(Script_AudioManager.buttonPress);
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}