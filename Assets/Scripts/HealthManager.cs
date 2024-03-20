using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class HealthManager : MonoBehaviour
{
    public List<GameObject> hearts; // Kalp objelerinin listesi
    public int maxHealth = 3; // Başlangıçta sahip olduğu maksimum can miktarı
    private int currentHealth; // Mevcut can miktarı

    public GameObject ball;

    public bool gameEnded = false; // Oyunun sonlandırıldığı bilgisi

    public bool gameFullEnded = false; // Oyunun tamemen bittiği bilgisi

    public TextMeshProUGUI readyText; // Hazır metin nesnesi

    private int sayac = 0;

    public UIController uiScript;

    public GameObject gameEndController;

    public GameObject uiBackground; // Hareket ettirilecek objelerin listesi
    public GameObject uiGameEnd; // Hareket ettirilecek objelerin listesi
    public GameObject uiReplay; // Hareket ettirilecek objelerin listesi
    public GameObject hiddenObject;
    public GameObject gameObjectsToActivateOnStart;

    void Start()
    {
        currentHealth = maxHealth; // Başlangıçta canı maksimuma ayarla
        Button replayButton = uiReplay.GetComponent<Button>();
        replayButton.onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Tetiklenen collider'ın etiketini kontrol et
        if (other.CompareTag("Player"))
        {
            // Kalp objelerinden birini yok et
            if (hearts.Count > 0)
            {
                Destroy(hearts[hearts.Count - 1]); // En üstteki kalbi yok et
                hearts.RemoveAt(hearts.Count - 1); // Listeden kalbi kaldır
                currentHealth--; // Can miktarını azalt
                ResetBallPosition(); // Topu başlangıç konumuna getir
                gameEnded = true;
                gameEndController.SetActive(false);
            }
            else
            {
                gameFullEnded = true; // Oyun Tamamen Bitti
                Debug.Log("Oyun Net Bitti");
                gameEndController.SetActive(true);
                hiddenObject.SetActive(false);
                ball.SetActive(false);
                Animation animationComponent1 = uiBackground.GetComponent<Animation>();
                animationComponent1.Play();
                Animation animationComponent2 = uiGameEnd.GetComponent<Animation>();
                animationComponent2.Play();
                Animation animationComponent3 = uiReplay.GetComponent<Animation>();
                animationComponent3.Play();
            }

            Debug.Log("Remaining health: " + currentHealth);

            if (gameEnded && sayac < 3)
            {
                EndGame();
                sayac++;
            }
        }
    }

    public void ResetBallPosition()
    {
        ball.transform.position = Vector3.zero; // Başlangıç konumu (0, 0, 0) olarak ayarlanır
        ball.transform.rotation = Quaternion.identity; // Başlangıç dönüşü (0, 0, 0, 1) olarak ayarlanır
    }

    public void EndGame()
    {
        StartCoroutine(FreezeGameForSeconds(3f));
    }

    IEnumerator FreezeGameForSeconds(float duration)
    {
        Time.timeScale = 0f; // Oyun zamanını durdur
        readyText.text = "3";
        yield return new WaitForSecondsRealtime(1f);

        readyText.text = "2";
        yield return new WaitForSecondsRealtime(1f);

        readyText.text = "1";
        yield return new WaitForSecondsRealtime(1f);

        readyText.text = "Ready!";
        yield return new WaitForSecondsRealtime(1f);
        readyText.text = "";
        Time.timeScale = 1f; // Oyun zamanını normale geri döndür
    }
}
