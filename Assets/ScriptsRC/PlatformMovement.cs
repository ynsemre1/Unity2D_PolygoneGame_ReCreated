using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformMovement : MonoBehaviour
{
    public float moveDistance = 2f;
    public float moveDuration = 1f;
    public Ease moveEaseType = Ease.Linear;

    private Vector3 rightLocalPosition;
    private Vector3 leftLocalPosition;
    private bool isMovingRight = true;

    public bool isPaused = false;

    void Start()
    {
        // Calculate the right and left positions (local)
        rightLocalPosition = transform.localPosition + Vector3.right * moveDistance;
        leftLocalPosition = transform.localPosition - Vector3.right * moveDistance;

        // Give the platform the initial movement command
        MovePlatform();
    }

    public void MovePlatform()
    {
        isPaused = false;
        // Determine the target position based on the movement direction (local)
        Vector3 targetLocalPosition = isMovingRight ? rightLocalPosition : leftLocalPosition;

        // Move the platform to the target position using tweening
        transform.DOLocalMove(targetLocalPosition, moveDuration).SetEase(moveEaseType).OnComplete(() =>
        {
            // When the movement is complete, reverse the movement direction and move the platform again
            isMovingRight = !isMovingRight;
            if (isPaused) return;
            MovePlatform();
        });
    }
}
