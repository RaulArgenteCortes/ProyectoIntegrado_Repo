using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento
    public float jumpForce = 7f; // Fuerza de salto
    public float gravity = 9.81f; // Gravedad
    public Transform groundCheck; // Para comprobar si el jugador está en el suelo
    public LayerMask groundMask; // La capa que representa el suelo

    private float groundDistance = 0.3f; // Distancia que determina si el jugador está tocando el suelo
    private bool isGrounded; // ¿Está el jugador en el suelo?
    private Vector3 velocity; // Movimiento en el eje Y (gravedad y salto)

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>(); // Obtenemos el CharacterController
    }

    void Update()
    {
        // Comprobamos si estamos en el suelo
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Para evitar que se quede flotando al estar en el suelo
        }

        // Movimiento horizontal (izquierda/derecha)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        controller.Move(move * moveSpeed * Time.deltaTime);

        // Salto (si estamos en el suelo y presionamos la tecla de salto)
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity); // Calculamos la fuerza de salto
        }

        // Aplicamos la gravedad
        velocity.y += gravity * Time.deltaTime;

        // Movemos al jugador en el eje Y (gravedad y salto)
        controller.Move(velocity * Time.deltaTime);
    }
}
