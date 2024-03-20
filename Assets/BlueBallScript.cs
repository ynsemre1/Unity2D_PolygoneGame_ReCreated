using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBallScript : MonoBehaviour
{
    public GameObject ball;
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            // Temas edilen objenin PlatformMovement bileşenini al
            PlatformMovement platformMovement = col.gameObject.GetComponent<PlatformMovement>();

            // Eğer temas edilen objenin PlatformMovement bileşeni varsa ve bu bileşenin isPaused değeri true değilse
            if (platformMovement != null && !platformMovement.isPaused)
            {
                // Temas edilen objenin PlatformMovement bileşeninin isPaused değerini true yap
                platformMovement.isPaused = true;
            }
            gameObject.SetActive(false);
            ball.SetActive(true);
        }
    }
}
