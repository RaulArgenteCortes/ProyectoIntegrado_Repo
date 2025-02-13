using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivation : MonoBehaviour
{
    [Header("Animation Efect")]
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite inactiveSprite;
    [SerializeField] Sprite activeSprite;
    [SerializeField] float activeDuration;
    float countdown;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        countdown = 0;
    }

    private void FixedUpdate()
    {
        SpriteCountdown();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //StartCoroutine(ChangeSprite());

            countdown = activeDuration;
        }
    }

    void SpriteCountdown()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
            spriteRenderer.sprite = activeSprite;
        }
        else
        {
            spriteRenderer.sprite = inactiveSprite;
        }
    }

    /*
    IEnumerator ChangeSprite()
    {
        spriteRenderer.sprite = activeSprite;
        for (int i = 0; i < 15; i++)
        {
            spriteRenderer.sprite = activeSprite;
            yield return new WaitForSeconds(0.1f);
        }
        spriteRenderer.sprite = inactiveSprite;
    }
    */
}
