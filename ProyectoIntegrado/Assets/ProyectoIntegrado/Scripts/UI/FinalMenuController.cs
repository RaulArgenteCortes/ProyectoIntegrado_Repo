using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalMenuController : MonoBehaviour
{
    [Header("Botones")]
    public Button button_FinalMenu_MainMenu;

    [Header("External Scripts")]
    [SerializeField] AudioManager Script_AudioManager;

    void Start()
    {
        button_FinalMenu_MainMenu.onClick.AddListener(LoadMainMenu);

        // Referencias a otros scripts
        Script_AudioManager = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();
    }

    void LoadMainMenu()
    {
        Script_AudioManager.PlaySfx(Script_AudioManager.buttonPress);

        SceneManager.LoadScene("MainMenu");
    }
}
