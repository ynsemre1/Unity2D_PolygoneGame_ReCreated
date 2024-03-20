using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public HealtManagerRC[] healthManagerRC;
    public Rigidbody2D ballRB;
    public GameObject defBall;
    public TextMeshProUGUI readyText;

    public void Start()
    {
        ballRB.AddForce(Vector2.up);
    }

    public void Update()
    {
        foreach (HealtManagerRC manager in healthManagerRC)
        {
            if(manager.gameStop)
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
}



