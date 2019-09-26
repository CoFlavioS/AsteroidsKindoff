using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float baseLife = 3f;
    public float life;
    public float damage = 1f;
    public GameObject death;

    private void Start()
    {
        life = baseLife;
    }

    void TakeDamage(float damage)
    {
        life -= damage;

        if (life <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        death.SetActive(true);
        Time.timeScale = 0f;
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Meteorite meteorite = collision.gameObject.GetComponent<Meteorite>();

        Debug.Log(collision.gameObject.name);

        if (meteorite != null)
        {
            TakeDamage(damage);
        }
    }
}