using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Permite cambiar de escenas.

public class SceneController : MonoBehaviour
{
    [Header("Escenas")] // No te olvides de añadir las escenas a "build settings".
    public string nextLevel;

    [Header("External Scripts")]
    [SerializeField] AudioManager Script_AudioManager;
    private void Start()
    {
        // Referencias a otros scripts
        Script_AudioManager = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision) // Cambia la escena cuando se llega a la meta.
    {
        if (collision.CompareTag("Player"))
        {
            Script_AudioManager.PlaySfx(Script_AudioManager.levelComplete);

            SceneManager.LoadScene(nextLevel);
        }
    }

    public void ExitGame()
    {
        Application.Quit(); // Cierra el juego por completo.
    }
}
