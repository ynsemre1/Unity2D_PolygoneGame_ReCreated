using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;

public class CharacterMove : NetworkBehaviour
{
    public float minX = -1.47f; // Minimum x pozisyonu
    public float maxX = 1.47f; // Maksimum x pozisyonu
    public float moveSpeed = 5f; // Hareket hızı

    private NetworkTransform networkTransform;

    void Start()
    {
        networkTransform = GetComponent<NetworkTransform>();
    }

    void Update()
    {
        // Check if the current client is not the owner of this character
        //if (!IsOwner) return;

        // Get input from arrow keys
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        // Calculate new position
        float newX = Mathf.Clamp(transform.position.x + moveX, minX, maxX);

        // Update the character's position
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}


