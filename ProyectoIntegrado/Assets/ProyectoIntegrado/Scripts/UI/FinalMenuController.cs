using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalMenuController : MonoBehaviour
{
    [Header("Botones")]
    public Button button_FinalMenu_MainMenu;

    void Start()
    {
        button_FinalMenu_MainMenu.onClick.AddListener(LoadMainMenu);
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
