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
            // Get the PlatformMovement component of the touched object

            PlatformMovement platformMovement = col.gameObject.GetComponent<PlatformMovement>();

            // If the touched object has a PlatformMovement component and the isPaused value of this component is not true
            if (platformMovement != null && !platformMovement.isPaused)
            {
                // Set the isPaused value of the touched object's PlatformMovement component to true
                platformMovement.isPaused = true;
                platformMovement.Invoke("MovePlatform", 3f);
            }
            gameObject.SetActive(false);
            ball.SetActive(true);
        }
    }
}
