using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveAndroid : MonoBehaviour
{
    // Hareket hızı
    public float moveSpeed = 5f;

    // Sınırlar
    public float minX = -1.47f;
    public float maxX = 1.47f;

    void Update()
    {
        // Parmak dokunuşlarını kontrol et
        foreach (Touch touch in Input.touches)
        {
            // Eğer parmak ekranın üzerine dokunuyorsa
            if (touch.phase == TouchPhase.Began)
            {
                // Karakterin collider'ı ile temas var mı kontrol et
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    // Dokunulan noktayı karakterin x koordinatı olarak ayarla
                    float targetX = Mathf.Clamp(Camera.main.ScreenToWorldPoint(touch.position).x, minX, maxX);
                    // Karakterin konumunu güncelle
                    transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
                    break;
                }
            }
        }
    }
}
