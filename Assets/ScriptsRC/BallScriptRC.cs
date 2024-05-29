using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScriptRC : MonoBehaviour
{
    public float minSpeed = 5f;
    public float maxSpeed = 10f;
    private Rigidbody2D ballRB;
    void Start()
    {
        ballRB = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Limiting the speed of the object
        float currentSpeed = ballRB.velocity.magnitude;
        if (currentSpeed < minSpeed)
        {
            ballRB.velocity = ballRB.velocity.normalized * minSpeed;
        }
        else if (currentSpeed > maxSpeed)
        {
            ballRB.velocity = ballRB.velocity.normalized * maxSpeed;
        }
    }
}
