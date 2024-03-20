using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
     void Update()
    {
        // Fare pozisyonunu al
        Vector3 farePozisyonu = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Karakteri fare pozisyonuna doğru hareket ettir
        transform.position = new Vector3(farePozisyonu.x, transform.position.y, transform.position.z);
    }
}

