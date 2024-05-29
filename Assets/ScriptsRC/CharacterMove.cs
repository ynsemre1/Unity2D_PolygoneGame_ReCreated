using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
     public float minX = -1.47f; // Minimum x pozisyonu
    public float maxX = 1.47f; // Maksimum x pozisyonu

    void Update()
    {
        Vector3 farePozisyonu = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Constrain the x position of the character within the specified range
        float kisitliX = Mathf.Clamp(farePozisyonu.x, minX, maxX);

        // Move character towards mouse position
        transform.position = new Vector3(kisitliX, transform.position.y, transform.position.z);
    }
}

