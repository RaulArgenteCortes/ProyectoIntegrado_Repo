using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] Rigidbody2D objectRb;

    [Header("Horizontal Movement")]
    [SerializeField] float speedH;
    [SerializeField] bool isFacingRight;

    [Header("Vertical Movement")]
    [SerializeField] float speedV;
    [SerializeField] bool isFacingUp;

    private void Start()
    {
        objectRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MovingH();

        MovingV();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3) // Impulsa al jugador en el Y opuesto
        {
            isFacingRight = !isFacingRight;
            isFacingUp = !isFacingUp;
        }
    }

    void MovingH()
    {
        if (isFacingRight == true)
        {
            objectRb.transform.position = new Vector2(objectRb.transform.position.x + speedH / 100, objectRb.transform.position.y);
        }
        else
        {
            objectRb.transform.position = new Vector2(objectRb.transform.position.x + speedH / -100, objectRb.transform.position.y);
        }
    }

    void MovingV()
    {
        if (isFacingRight == true)
        {
            objectRb.transform.position = new Vector2(objectRb.transform.position.x, objectRb.transform.position.y + speedV / 100);
        }
        else
        {
            objectRb.transform.position = new Vector2(objectRb.transform.position.x, objectRb.transform.position.y + speedV / -100);
        }
    }
}
