using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceController : MonoBehaviour
{
    public AudioClip carpismaSes; // Çarpışma sesi
    public AudioClip wallSes; // Çarpışma sesi

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // AudioSource bileşenine erişim
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Çarpışan obje "Enemy" etiketine sahip ise ve çarpışma sesi atanmışsa
        if (collision.gameObject.CompareTag("Enemy") && carpismaSes != null)
        {
            audioSource.clip = carpismaSes; // Ses kaynağının çalacağı sesi belirle
            audioSource.Play(); // Ses kaynağını çal
        }
        if (collision.gameObject.CompareTag("Wall") && wallSes != null)
        {
            audioSource.clip = wallSes; // Ses kaynağının çalacağı sesi belirle
            audioSource.Play(); // Ses kaynağını çal
        }
    }

    
}
