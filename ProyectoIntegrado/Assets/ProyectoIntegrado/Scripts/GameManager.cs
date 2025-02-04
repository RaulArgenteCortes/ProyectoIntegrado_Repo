using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameState { MainMenu, Playing, Paused, GameOver, Victory }
    public GameState currentState;

    //Variables
    public int score = 0;
    public int playerlives = 1;
    public bool isPaused = false;

    //UI

    public GameObject MainMenuUI;
    public GameObject gameOverUI;
    public GameObject pauseMenuUI;
    public GameObject victoryUI;



    void Awake()
    {
        //Singleton (asegurarse de que solo hay una instancia del Game Manager)
        if (instance == null)
        {
            instance = this;

        }


        else if (instance != this)
        {
            Destroy(gameObject);
        }


    }
    void Start()
    {
        // Inicia el juego en el estado del menú principal
        ChangeGameState(GameState.MainMenu);
    }

    void Update()
    {
        //Actalización de acurdo al estado del juego
        switch (currentState)
        {




            case GameState.MainMenu:
                //Aqui podías tener la lógica para iniciar el juego etc.
                break;
            case GameState.Playing:
                //Lógica para el juengo en progresa
                
                HandleInput();
                break;

            case GameState.Paused:
                break;
            case GameState.GameOver:
                break;
            case GameState.Victory:
                break;
        
               
        }

    
    }

    public void ChangeGameState (GameState newState)
    {
        currentState = newState;
        switch (currentState)
        {
      case GameState.MainMenu:
                ShowMainMenu();
        break;

            case GameState.Playing:
                StartGame();
                break;

            case GameState.Paused:
                ShowPauseMenu();
                break;

            case GameState.GameOver:
                ShowGameOverScreen();
                break;
            
            case GameState.Victory:
                ShowVictoryScreen();
                break;
        }
}
    private void ShowMainMenu()
    {
        pauseMenuUI.SetActive(true);
        gameOverUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        victoryUI.SetActive(false);
        Time.timeScale = 0;
    }

    private void ShowPauseMenu()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;

    }
    private void ShowGameOverScreen()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }
    private void ShowVictoryScreen()
    {
        victoryUI.SetActive(true);
        Time.timeScale = 0;
    }
    private void StartGame()
    {
        score = 0;
        playerlives = 1;
        isPaused = false;
        MainMenuUI.SetActive(false);
        Time.timeScale = 1;
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
public void TogglePause()
    {
        if (currentState == GameState.Paused)
        {
            ChangeGameState(GameState.Playing);
        }

        else
        {
            ChangeGameState(GameState.Paused);
        }
            }

    public void GameOver()
    {
        ChangeGameState(GameState.GameOver);
    }
    public void Victory()
    {
        ChangeGameState(GameState.Victory);

    }
        }
   
   




