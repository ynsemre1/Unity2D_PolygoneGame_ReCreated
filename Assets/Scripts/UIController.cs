using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class UIController : MonoBehaviour
{
    public RectTransform startText;
    public RectTransform easyText;
    public RectTransform normalText;
    public RectTransform hardText;
    public RectTransform background;
    public RectTransform Polygone;

    public Button startButton;
    public bool gameStarted;
    public GameObject gameObjectsToActivateOnStart; // Başlatıldığında aktif olacak oyun nesneleri
    public Rigidbody2D ballRigidbody;
    public float baslangicKuvvet = 3f;

    void Start()
    {
        startButton.onClick.AddListener(MoveUIElements);
        // Oyun nesnelerini aktifleştir
        startButton.onClick.AddListener(StartGame);
        // Oyun başladı bayrağını işaretle
        gameStarted = true;
    }

    void MoveUIElements()
    {
        float duration = 2f; // Hareket süresi

        // Start yazısı için hareket animasyonu
        startText.DOAnchorPosY(750, duration).SetEase(Ease.OutBounce);

        // Diğer yazılar için gecikmeli hareket animasyonları
        float delay = 0.2f;
        easyText.DOAnchorPosY(750, duration).SetEase(Ease.OutBounce).SetDelay(delay);
        normalText.DOAnchorPosY(750, duration).SetEase(Ease.OutBounce).SetDelay(delay * 2);
        hardText.DOAnchorPosY(750, duration).SetEase(Ease.OutBounce).SetDelay(delay * 3);

        // Arka plan için hareket animasyonu
        background.DOAnchorPosY(750, duration).SetEase(Ease.OutBounce).SetDelay(delay * 5);
        Polygone.DOAnchorPosY(750, duration).SetEase(Ease.OutBounce).SetDelay(delay * 2);
    }
    void StartGame()
    {
        // StartGameCoroutine işlevini başlat
        StartCoroutine(StartGameCoroutine());
    }

    IEnumerator StartGameCoroutine()
    {
        yield return new WaitForSeconds(1f);

        // Oyun nesnelerini aktifleştir
        gameObjectsToActivateOnStart.SetActive(true);

        // Rastgele bir yön belirle (sağa veya sola)
        float direction = Random.Range(0, 2) == 0 ? -1 : 1;
        // Başlangıç kuvvetini hesapla
        Vector2 initialForce = new Vector2(direction * baslangicKuvvet, 0f);
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = 0f;
        // Topa başlangıç kuvvetini uygula
        ballRigidbody.AddForce(initialForce, ForceMode2D.Impulse);
        Debug.Log("Baslangic Kuvveti Uygulandi");
    }
}


