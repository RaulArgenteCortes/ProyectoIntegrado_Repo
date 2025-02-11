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

    void Start()
    {
        // Asigna las funciones de los botones.

        button_MainMenu_Levels.onClick.AddListener(OpenLevels);
        button_MainMenu_Help.onClick.AddListener(OpenHelp);
        button_MainMenu_Exit.onClick.AddListener(CloseGame);

        button_Levels_Back.onClick.AddListener(OpenMainMenu);

        button_Help_Back.onClick.AddListener(OpenMainMenu);


        // Desactiva todos los paneles excepto MainMenu.

        OpenMainMenu();
    }

    void OpenMainMenu()
    {
        panel_MainMenu.SetActive(true);
        panel_Levels.SetActive(false);
        panel_Help.SetActive(false);
    }

    void OpenLevels()
    {
        panel_MainMenu.SetActive(false);
        panel_Levels.SetActive(true);
        panel_Help.SetActive(false);
    }

    void OpenHelp()
    {
        panel_MainMenu.SetActive(false);
        panel_Levels.SetActive(false);
        panel_Help.SetActive(true);
    }

    void CloseGame()
    {
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}