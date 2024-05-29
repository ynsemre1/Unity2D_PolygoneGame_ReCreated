using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    public TrailRenderer trailRenderer;
    private Color objectColor;
    public HardLight2D hardLight2D;
    public SpriteRenderer altigen;

    void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Color"))
        {
            // Get the color of the colliding object

            objectColor = other.GetComponent<Renderer>().material.color;

            // If you want to change the color of the ball:
            GetComponent<Renderer>().material.color = objectColor;
            trailRenderer.startColor = objectColor;

            hardLight2D.Color = objectColor;
            altigen.color = objectColor;
        }
    }
}
