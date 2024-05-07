using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
     public float minX = -1.47f; // Minimum x pozisyonu
    public float maxX = 1.47f; // Maksimum x pozisyonu

    void Update()
    {
        // Fare pozisyonunu al
        Vector3 farePozisyonu = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Karakterin x pozisyonunu belirtilen aralıkta kısıtla
        float kisitliX = Mathf.Clamp(farePozisyonu.x, minX, maxX);

        // Karakteri fare pozisyonuna doğru hareket ettir
        transform.position = new Vector3(kisitliX, transform.position.y, transform.position.z);
    }
}

