using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject ball;
    // Start is called before the first frame update
    public float accelerationRate = 0.001f; // Hızlanma miktarı
    public float accelerationDuration = 3f; // Hızlanma süresi

    private float originalMoveDuration; // Orijinal hareket süresi
    private Coroutine resetSpeedCoroutine; // Hızı resetleme işlemi için coroutine

    void Start()
    {
        // Orijinal hareket süresini kaydet
        //originalMoveDuration = moveDuration;

        // Platforma ilk hareket komutunu ver
        //MovePlatform();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            PlatformMovement platformMovement = col.gameObject.GetComponent<PlatformMovement>();
            originalMoveDuration = platformMovement.moveDuration;

            if (platformMovement != null && !platformMovement.isPaused)
            {
                // Hareket süresini kısaltarak hızlanmayı sağla
                platformMovement.moveDuration -= accelerationRate;

                // Eğer hareket süresi minimum değerden küçükse, minimum değere sabitle
                if (platformMovement.moveDuration < 0.1f)
                {
                    platformMovement.moveDuration = 0.1f; // Minimum değeri istediğiniz değer olarak belirleyebilirsiniz
                }

                // Hızı belirli bir süre sonra eski değerine geri döndürmek için coroutine başlat
                if (resetSpeedCoroutine != null)
                {
                    // Daha önce başlatılan bir coroutine varsa, iptal et
                    StopCoroutine(resetSpeedCoroutine);
                }
                resetSpeedCoroutine = StartCoroutine(ResetSpeedAfterDelay(platformMovement));
            }
            gameObject.SetActive(false);
            ball.SetActive(true);
        }
    }

    // Belirli bir süre sonra hızı eski değerine geri döndürmek için coroutine
    private IEnumerator ResetSpeedAfterDelay(PlatformMovement platformMovement)
    {
        yield return new WaitForSeconds(accelerationDuration);

        // Hızı eski değerine geri döndür
        platformMovement.moveDuration = originalMoveDuration;
    }
}
