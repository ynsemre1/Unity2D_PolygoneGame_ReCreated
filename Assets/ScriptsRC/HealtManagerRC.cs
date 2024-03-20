using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtManagerRC : MonoBehaviour
{
    public GameObject[] coinObjects; // Alt objeler (coin'ler)
    private int currentHealth; // Mevcut can miktarı
    public bool gameOver = false;
    public bool gameStop = false;

    void Start()
    {
        // Başlangıçta mevcut can miktarını belirle (coin sayısı kadar)
        currentHealth = coinObjects.Length + 1; // Coin sayısına 1 ekleyerek başlangıçta 4 can yapar
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Top, ana objenin collider'ına çarptığında
        if (other.CompareTag("Ball"))
        {
            gameStop = true;
            Debug.Log("OyunDurdu");
            // Her çarpışmada canı 1 artır
            currentHealth--;

            // Eğer can 4'e ulaştıysa, oyunu bitir
            if (currentHealth == 0)
            {
                gameOver = true;
            }
            else
            {
                // Her bir coin objesinin aktifliğini güncelle
                for (int i = 0; i < coinObjects.Length; i++)
                {
                    coinObjects[i].SetActive(i < currentHealth - 1);
                }
            }
        }
    }
}
