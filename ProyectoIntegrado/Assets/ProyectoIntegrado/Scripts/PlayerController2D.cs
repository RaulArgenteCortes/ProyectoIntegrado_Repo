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
    private Vector3 moveInput; //Almac�n del input del player
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
        if (collision.gameObject.CompareTag("Boost_TallJump"))
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, playerRb.velocity.y / Mathf.Abs(playerRb.velocity.y) * -24); // Impulsa al jugador en el Y opuesto
        }
        else if (collision.gameObject.CompareTag("Boost_LongJump"))
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x / Mathf.Abs(playerRb.velocity.x) * 24, playerRb.velocity.y); // Impulsa al jugador en el X
        }
    }

    void Movement()
    {
        playerRb.velocity = new Vector3(moveInput.x * speed, playerRb.velocity.y, 0); // Sin deslizamiento
        //playerRb.AddForce(Vector3.right * moveInput.x * speed); // Con deslizamiento
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
        // Conector de valores generales con parametros de animaci�n

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
