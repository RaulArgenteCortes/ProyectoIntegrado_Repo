using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class FadingUI : MonoBehaviour
{
    public float fadeTime;
    private TextMeshProUGUI fadeAwayText;
    [SerializeField] float textMovement;

    private void Start()
    {
        fadeAwayText = GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        if (fadeTime > 0) 
        { 
            fadeTime -= Time.deltaTime;
            fadeAwayText.color = new Color(fadeAwayText.color.r, fadeAwayText.color.g, fadeAwayText.color.b, fadeTime / 4);
            fadeAwayText.transform.position = new Vector2(fadeAwayText.transform.position.x, fadeAwayText.transform.position.y + textMovement);
        }
    }
}
