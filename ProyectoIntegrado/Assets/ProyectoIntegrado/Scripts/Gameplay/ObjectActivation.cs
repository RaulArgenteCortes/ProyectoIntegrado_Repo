using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ObjectActivation : MonoBehaviour
{
    [Header("Animation Efect")]
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite inactiveSprite;
    [SerializeField] Sprite activeSprite;
    bool isActive;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ChangeSprite());
        }
    }

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
}
