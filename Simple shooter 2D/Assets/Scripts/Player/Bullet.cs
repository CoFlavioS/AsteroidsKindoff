using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    private float timecount;
    public float lifespan = 5;

    void Start()
    {
        rb.velocity = transform.up * speed;
        timecount = lifespan;
    }

    private void Update()
    {
        timecount -= Time.deltaTime;

        if (timecount <= 0)
        {
            Destroy(gameObject);
        }

        if (timecount <= -20) timecount = -18;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Meteorite meteorite = collision.GetComponent<Meteorite>();

        if (meteorite != null)
        {
            meteorite.life -= 1;
            Destroy(gameObject);
        }
    }
}
