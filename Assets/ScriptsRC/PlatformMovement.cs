using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformMovement : MonoBehaviour
{
    public float moveDistance = 2f;
    public float moveDuration = 1f;
    public Ease moveEaseType = Ease.Linear;

    private Vector3 rightLocalPosition;
    private Vector3 leftLocalPosition;
    private bool isMovingRight = true;

    public bool isPaused = false;

    void Start()
    {
        // Sağ ve sol pozisyonları hesapla (yerel)
        rightLocalPosition = transform.localPosition + Vector3.right * moveDistance;
        leftLocalPosition = transform.localPosition - Vector3.right * moveDistance;

        // Platforma ilk hareket komutunu ver
        MovePlatform();
    }

    public void MovePlatform()
    {
            isPaused = false;
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

