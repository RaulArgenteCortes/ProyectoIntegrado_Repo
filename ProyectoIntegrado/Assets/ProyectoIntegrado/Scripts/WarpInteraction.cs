using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpInteraction : MonoBehaviour
{
    [SerializeField] Rigidbody2D objectRb;

    private void Start()
    {
        objectRb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WarpH")) // Invierte la posición en X del objeto
        {
            objectRb.transform.position = new Vector2(objectRb.transform.position.x * -1f, objectRb.transform.position.y);
        }
        else if (collision.gameObject.CompareTag("WarpV")) // Invierte la posición en Y del objeto
        {
            objectRb.transform.position = new Vector2(objectRb.transform.position.x, objectRb.transform.position.y * -1f);
        }
    }
}
