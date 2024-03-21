using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using DG.Tweening;
using TMPro;

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

    public void Start()
    {
        ballRB.AddForce(Vector2.up);

        InvokeRepeating("RandomEvent", 1f, 30f);
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
        string functionName = "Event" + Random.Range(2, 3); // 1 ve 2 arasında rastgele bir fonksiyon adı seç
        Invoke(functionName, randomDelay);
        Debug.Log(randomDelay);
    }

    void Event1()
    {
        Debug.Log("Event1 Called");
        defBall.SetActive(false);
        blueBall.SetActive(true);
    }

    void Event2()
    {
        Debug.Log("Event2 Called");
        defBall.SetActive(false);
        fireBall.SetActive(true);
    }
}



