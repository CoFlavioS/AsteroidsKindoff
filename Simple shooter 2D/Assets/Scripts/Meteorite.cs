using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    public bool hit = false;
    public Collider2D col;
    public float speed = 7.5f;
    public Rigidbody2D rb;

    private void Start()
    {
        rb.velocity = transform.right * speed;
        col.isTrigger = true;
    }

    void Update()
    {
        if (hit)
        {
            Die();
        }

        if (transform.position.x < 8 && transform.position.x > -8 && transform.position.y < 4 && transform.position.y > -4)
        {
            col.isTrigger = false;
        }

        if (transform.position.x < -20 || transform.position.x > 20 || transform.position.y < -20 || transform.position.y > 20)
        {
            Destroy(gameObject);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
