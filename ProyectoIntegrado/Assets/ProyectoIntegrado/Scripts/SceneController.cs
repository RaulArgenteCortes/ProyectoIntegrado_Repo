using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Permite cambiar de escenas.

public class SceneController : MonoBehaviour
{
    [Header("Escenas")] // No te olvides de a�adir las escenas a "build settings".
    public string nextLevel;

    private void OnTriggerEnter2D(Collider2D collision) // Cambia la escena cuando se llega a la meta.
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextLevel);
        }
    }

    public void ExitGame()
    {
        Application.Quit(); // Cierra el juego por completo.
    }
}
