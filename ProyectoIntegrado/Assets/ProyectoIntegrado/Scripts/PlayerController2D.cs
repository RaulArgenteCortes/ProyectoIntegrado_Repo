using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class PlayerController2D : MonoBehaviour
{
    // Referencias generales
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] Animator playerAnim;

    [Header("Movement Parameters")]
    [SerializeField] private Vector3 moveInput; //Almacén del input del player
    public float speed;
    [SerializeField] bool isFacingRight;

    [Header("Jump Parameters")]
    public float jumpForce;
    [SerializeField] bool isGrounded;
    // Variables para el GroundCheck
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius = 0.1f;
    [SerializeField] LayerMask groundLayer;

    void Start()
    {
        // Autoreferenciar componentes: nombre de variable = GetComponent()
        playerRb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        playerAnim = GetComponent<Animator>();
        isFacingRight = true;
    }

    void Update()
    {
        HandleAnimations();

        GroundCheck();

        if (moveInput.x > 0)
        {
            if (!isFacingRight)
            {
                Flip();
            }
        }
        if (moveInput.x < 0)
        {
            if (isFacingRight)
            {
                Flip();
            }
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WarpH")) // Invierte la posición en X del jugador
        {
            playerRb.transform.position = new Vector2(playerRb.transform.position.x * -1, playerRb.transform.position.y);
        }
        else if (collision.gameObject.CompareTag("WarpV")) // Invierte la posición en Y del jugador
        {
            playerRb.transform.position = new Vector2(playerRb.transform.position.x, playerRb.transform.position.y * -1);
        }
        else if (collision.gameObject.CompareTag("Boost_Teleport")) // Teletransporta al jugador
        {
            //collision.gameObject.TeleportPlayer();
        }
        else if (collision.gameObject.CompareTag("Boost_TallJump")) // Impulsa al jugador en el Y opuesto
        {
            if (playerRb.velocity.y <= 0)
            {
                playerRb.velocity = new Vector2(playerRb.velocity.x, 24);
            } 
            else
            {
                playerRb.velocity = new Vector2(playerRb.velocity.x, -24);
            }
        }
        else if (collision.gameObject.CompareTag("Boost_LongJump")) // Impulsa al jugador en el X y en el Y opuesto
        {
            if (playerRb.velocity.y <= 0)
            {
                playerRb.velocity = new Vector2(speed * moveInput.x * 2, jumpForce);
            }
            else
            {
                playerRb.velocity = new Vector2(speed * moveInput.x * 2, jumpForce * -1);
            }
        }
        else if (collision.gameObject.CompareTag("Boost_BounceJump")) // Impulsa al jugador en el X opuesto y en el Y
        {
            if (playerRb.velocity.y <= 0)
            {
                if (playerRb.velocity.x >= 0)
                {
                    playerRb.velocity = new Vector2(speed * -2, jumpForce * -1);
                }
                else if (playerRb.velocity.x <= 0)
                {
                    playerRb.velocity = new Vector2(speed * 2, jumpForce * -1);
                }
            }
            else
            {
                if (playerRb.velocity.x >= 0)
                {
                    playerRb.velocity = new Vector2(speed * -2, jumpForce);
                }
                else if (playerRb.velocity.x <= 0)
                {
                    playerRb.velocity = new Vector2(speed * 2, jumpForce);
                }
            }
        }
        else if (collision.gameObject.CompareTag("Death")) // Mata al jugador
        {
            RestartScene();
        }
    }

    void Movement()
    {
        playerRb.AddForce(Vector3.right * moveInput.x * speed);

        // Reduce el deslizamiento
        if (moveInput.x == 0 && playerRb.velocity.x < 0.1 && playerRb.velocity.x > -0.1) // Detiene al jugador cuando no hay input y apenas se mueva
        {
            playerRb.velocity = new Vector3(0, playerRb.velocity.y, 0);
        }
        else if (playerRb.velocity.x > 0 && moveInput.x != 1) // Frena al jugador cuando no hay input
        {
                playerRb.AddForce(Vector3.right * playerRb.velocity.x * -3);
        }
        else if (playerRb.velocity.x < -0 && moveInput.x != -1) // Frena al jugador cuando no hay input
        {
            playerRb.AddForce(Vector3.right * playerRb.velocity.x * -3);
        } 
    }

    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        isFacingRight = !isFacingRight; // !bool = su opuesto
    }

    void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void HandleAnimations()
    {
        // Conector de valores generales con parametros de animación

        if (playerRb.velocity.y > 0.01)
        {
            playerAnim.SetBool("isJumping", true);
            playerAnim.SetBool("isFalling", false);
        }
        else if (playerRb.velocity.y < 0.01 && isGrounded == false)
        {
            playerAnim.SetBool("isJumping", false);
            playerAnim.SetBool("isFalling", true);
        }
        else
        {
            playerAnim.SetBool("isJumping", false);
            playerAnim.SetBool("isFalling", false);
        }

        if (moveInput.x > 0 || moveInput.x < 0) 
        { 
            playerAnim.SetBool("isRunning", true); 
        }
        else 
        { 
            playerAnim.SetBool("isRunning", false); 
        }
    }

    private static void RestartScene()
    {
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    #region Input Events

    // Para crear un evento:
    /*
        public void Handle'movimiento'(InputAction.CallbackContext context)
        {
            
        }
    */

    public void HandleMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void HandleJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (isGrounded)
            {
                playerRb.velocity = new Vector3(playerRb.velocity.x, 0, 0); // Reinicia la caida para evitar antisaltos
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    public void HandleReset(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            RestartScene();
        }
    }

    #endregion
}
