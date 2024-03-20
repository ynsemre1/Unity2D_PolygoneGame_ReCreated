using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformMovement : MonoBehaviour
{
    public float moveDistance = 5f; // Hareket mesafesi
    public float moveDuration = 2f; // Hareket süresi
    public Ease moveEaseType = Ease.OutQuad; // Hareket yumuşaklığı

    private Vector3 rightLocalPosition; // Sağ pozisyon (yerel)
    private Vector3 leftLocalPosition;  // Sol pozisyon (yerel)
    private bool isMovingRight = true; // Sağa mı hareket ediliyor?
    public bool isPaused = false; // Durduruldu mu?

    void Start()
    {
        // Sağ ve sol pozisyonları hesapla (yerel)
        rightLocalPosition = transform.localPosition + Vector3.right * moveDistance;
        leftLocalPosition = transform.localPosition - Vector3.right * moveDistance;

        // Platforma ilk hareket komutunu ver
        MovePlatform();
    }

    void MovePlatform()
    {
        
            // Hareket yönüne göre hedef pozisyonu belirle (yerel)
            Vector3 targetLocalPosition = isMovingRight ? rightLocalPosition : leftLocalPosition;

            // Tweening ile platformu hedef pozisyona hareket ettir
            transform.DOLocalMove(targetLocalPosition, moveDuration).SetEase(moveEaseType).OnComplete(() =>
            {
                // Hareket tamamlandığında hareket yönünü tersine çevir ve platformu tekrar hareket ettir
                isMovingRight = !isMovingRight;
                if(isPaused) return;
                MovePlatform();
            });
        
    }

}
