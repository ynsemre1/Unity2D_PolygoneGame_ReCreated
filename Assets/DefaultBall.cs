using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBall : MonoBehaviour
{
    IEnumerator DelayedExecution(PlatformMovement platformMovement)
{
    yield return new WaitForSeconds(3f); // 3 saniye bekle

    if (platformMovement != null && !platformMovement.isPaused)
    {
        if(platformMovement.moveDuration < .2f) platformMovement.moveDuration = 0.5f;
        // Minimum değeri istediğiniz değer olarak belirleyebilirsiniz
    }
}

void OnTriggerEnter2D(Collider2D col)
{
    if (col.gameObject.CompareTag("Enemy"))
    {
        PlatformMovement platformMovement = col.gameObject.GetComponent<PlatformMovement>();

        if (platformMovement != null && !platformMovement.isPaused)
        {
            StartCoroutine(DelayedExecution(platformMovement));
        }
    }
}
}
