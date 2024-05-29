using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagerRC : MonoBehaviour
{
    public GameObject[] coinObjects; // Coin objects
    public GameObject[] expObjects;
    private int currentHealth; // Current health amount
    public bool gameOver = false;
    public bool gameStop = false;

    private AudioSource audioSource;
    public AudioClip collisionSound; // GameOver sound


    void Start()
    {
        // Determine the initial amount of health (number of coins + 1)
        currentHealth = coinObjects.Length + 1; // By adding 1 to the number of coins, we start with 4 health

        audioSource = GetComponent<AudioSource>(); // Access the AudioSource component
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // When the ball collides with the main object's collider
        if (other.CompareTag("Ball"))
        {
            gameStop = true;
            Debug.Log("GameStopped");
            // Decrease health by 1 on each collision
            currentHealth--;

            // If health reaches 0, end the game
            if (currentHealth == 0)
            {
                gameOver = true;
            }
            else
            {
                // Update the active state of each coin object
                for (int i = 0; i < coinObjects.Length; i++)
                {
                    coinObjects[i].SetActive(i < currentHealth - 1);
                }
            }

            audioSource.clip = collisionSound; // Set the sound to be played by the audio source
            audioSource.Play(); // Play the audio source
        }
    }
}
