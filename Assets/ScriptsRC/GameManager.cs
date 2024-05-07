using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public Rigidbody2D ballRB;
    public GameObject defBall;
    public GameObject blueBall;
    public GameObject fireBall;
    public HealtManagerRC[] healthManagerRC;
    public TextMeshProUGUI readyText;
    public HardLight2D hardLight2D;

    public GameObject game;

    public Button startButton;
    public Button stopButton;
    public Button restartButton;
    public Button quitButton;

    public void Start()
    {
        Time.timeScale = 0;

        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        // Topa rastgele bir kuvvet uygula
        ballRB.AddForce(randomDirection * 2f, ForceMode2D.Impulse);

        InvokeRepeating("RandomEvent", 7f, 10f);

        startButton.onClick.AddListener(StartButtonClick);
        stopButton.onClick.AddListener(StopButtonClick);
        restartButton.onClick.AddListener(RestartButtonClick);
        quitButton.onClick.AddListener(QuitButtonClick);
    }

    public void Update()
    {

        foreach (HealtManagerRC manager in healthManagerRC)
        {
            if (manager.gameStop)
            {
                Debug.Log("Oyun Durdu");
                ball.SetActive(false);
                ResetBallPositionRC();
                readyText.gameObject.SetActive(true);

            }
            if (manager.gameOver)
            {
                // HealthManagerRC örneği gameOver true ise buraya girecek kodlar
                Debug.Log("Oyun bitti!");
                ball.SetActive(false);
                Time.timeScale = 0;
                //UI Panel Gelir
            }
        }
    }

    public void ResetBallPositionRC()
    {
        ball.SetActive(true);
        defBall.GetComponent<Renderer>().material.color = Color.white;
        hardLight2D.Color = Color.white;
        ball.transform.position = Vector3.zero; // Başlangıç konumu (0, 0, 0) olarak ayarlanır
        ball.transform.rotation = Quaternion.identity; // Başlangıç dönüşü (0, 0, 0, 1) olarak ayarlanır

        StartCoroutine(FreezeGameForSeconds(3f));
        readyText.gameObject.SetActive(false);
        foreach (HealtManagerRC manager in healthManagerRC)
        {
            manager.gameStop = false;
        }
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        // Topa rastgele bir kuvvet uygula
        ballRB.AddForce(randomDirection * 2f, ForceMode2D.Impulse);
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
        readyText.gameObject.SetActive(false);

        Time.timeScale = 1f; // Oyun zamanını normale geri döndür
    }

    void RandomEvent()
    {
        float randomDelay = Random.Range(3f, 10f); // Her fonksiyon arasında 3 ile 10 saniye arasında rastgele bir gecikme sağla
        string functionName = "Event" + Random.Range(1, 3); // 1 ve 2 arasında rastgele bir fonksiyon adı seç
        Invoke(functionName, randomDelay);
        Debug.Log(randomDelay);
    }

    void Event1()
    {
        // TODO: Event Name Changed
        
        Debug.Log("FireBall Called");
        defBall.SetActive(false);
        blueBall.SetActive(true);
    }

    void Event2()
    {
        // TODO: Event Name Changed

        Debug.Log("Event2 Called");
        defBall.SetActive(false);
        fireBall.SetActive(true);
    }

    void StartButtonClick()
    {
        // Zaman ölçeğini 1'e ayarla (oyunu başlat)
        Time.timeScale = 1f;
    }

    void StopButtonClick()
    {
        if (Time.timeScale == 1) Time.timeScale = 0f;
        else Time.timeScale = 1f;

        TextMeshProUGUI buttonText = stopButton.GetComponentInChildren<TextMeshProUGUI>();
        if (Time.timeScale == 0) buttonText.text = "Resume";
        else buttonText.text = "Stop";
    }

    void RestartButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    void QuitButtonClick()
    {
        // Zaman ölçeğini 1'e ayarla (oyunu başlat)
        Application.Quit();
    }
}



