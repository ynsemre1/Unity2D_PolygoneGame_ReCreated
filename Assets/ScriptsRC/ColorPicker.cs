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
            // Çarpışma yapan objenin rengini al
            objectColor = other.GetComponent<Renderer>().material.color;

            // Topun rengini değiştirmek isterseniz:
            GetComponent<Renderer>().material.color = objectColor;
            trailRenderer.startColor = objectColor;

            hardLight2D.Color = objectColor;
            altigen.color = objectColor;
        }
    }
}
