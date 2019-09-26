using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public Rigidbody2D rb;

    public float accel = 0.3f;
    float movementX = 0f;
    float movementY = 0f;

    private void Update()
    {
        movementX = Input.GetAxis("Horizontal");
        movementY = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movementX * accel, movementY * accel);
    }
}