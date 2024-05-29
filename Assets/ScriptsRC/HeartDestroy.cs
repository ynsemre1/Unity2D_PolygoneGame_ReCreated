using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeartDestroy : MonoBehaviour
{
    public TextMeshProUGUI healtRecyler;
    public int healtSayac;

    void Start()
    {
        healtSayac = 0;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Çarpışan nesnenin "Kalp" tag'ine sahip olup olmadığını kontrol et
        if (other.CompareTag("Healt"))
        {
            // Kalp nesnesini yok et
            Destroy(other.gameObject);
            healtSayac++;
            healtRecyler.text = ("HEART : " + healtSayac);
        }
    }
}
