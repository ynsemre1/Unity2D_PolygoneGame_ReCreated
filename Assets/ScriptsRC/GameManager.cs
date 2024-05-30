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
    public HealthManagerRC[] healthManagerRC;
    public TextMeshProUGUI readyText;
    public HardLight2D hardLight2D;

    public Button startButton;
    public Button stopButton;
    public Button restartButton;
    public Button quitButton;

    public void Start()
    {
        Time.timeScale = 0;

        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        // Apply a random force to the ball
        ballRB.AddForce(randomDirection * 2f, ForceMode2D.Impulse);

        InvokeRepeating("RandomEvent", 7f, 10f);

        startButton.onClick.AddListener(StartButtonClick);
        stopButton.onClick.AddListener(StopButtonClick);
        restartButton.onClick.AddListener(RestartButtonClick);
        quitButton.onClick.AddListener(QuitButtonClick);
    }

    public void Update()
    {

        foreach (HealthManagerRC manager in healthManagerRC)
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
                // HealthManagerRC example If gameOver is true, the codes will enter here
                Debug.Log("Oyun bitti!");
                ball.SetActive(false);
                Time.timeScale = 0;
            }
        }
    }

    public void ResetBallPositionRC()
    {
        ball.SetActive(true);
        defBall.GetComponent<Renderer>().material.color = Color.white;
        hardLight2D.Color = Color.white;
        ball.transform.position = Vector3.zero; // Starter Pos (0, 0, 0) 
        ball.transform.rotation = Quaternion.identity; // Starter Rot (0, 0, 0, 1) 

        StartCoroutine(FreezeGameForSeconds(3f));
        readyText.gameObject.SetActive(false);
        foreach (HealthManagerRC manager in healthManagerRC)
        {
            manager.gameStop = false;
        }
        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        //Apply a random force to the ball
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
        float randomDelay = Random.Range(3f, 10f); // Provide a random delay between 3 and 10 seconds between each function
        string functionName = "Event" + Random.Range(1, 3); //choose a random function name between 1 and 2
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
        Application.Quit();
    }
}



