using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    public int life = 1;
    public int level = 0;
    public float maxV = 1;
    public float speed = 7.5f;
    public Rigidbody2D rb;
    public Meteorite meteoritePrefab;
    public PlayerController player;

    private void Start()
    {
        if (level == 0) {
        level = 3;
        }
        life = 1;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        rb.velocity = transform.right * speed;
        gameObject.transform.localScale *= level;
    }

    void Update()
    {
        if (life <= 0)
        {
            Die();
        }

        if (Mathf.Abs(rb.velocity.x) > 4) rb.velocity = new Vector2(maxV * Mathf.Sign(rb.velocity.x), rb.velocity.y);
        if (Mathf.Abs(rb.velocity.y) > 4) rb.velocity = new Vector2(rb.velocity.x, maxV * Mathf.Sign(rb.velocity.y));
    }

    void Die()
    {
        player.points += (level + player.life) * 5;
        if (level > 1)
        {
            gameObject.transform.localScale = new Vector3(5, 5, 1);
            Meteorite go1 = Instantiate(meteoritePrefab, transform.position + Vector3.right * 0.5f, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
            go1.level = level - 1;
            Meteorite go2 = Instantiate(meteoritePrefab, transform.position + Vector3.left * 0.5f, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
            go2.level = level - 1;
        }
        Destroy(gameObject);
    }
}
