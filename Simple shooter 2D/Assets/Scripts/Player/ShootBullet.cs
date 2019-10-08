using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public float frecuency = 0.5f;
    private float timeCount = 0;
    public SpriteRenderer origin;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int maxBullets = 2;
    public int bulletsLeft;

    private void Start()
    {
        timeCount = frecuency;
    }
    void Update()
    {
        bulletsLeft = GameObject.FindGameObjectsWithTag("Bullet").Length;

        timeCount -= Time.deltaTime;

        if (Input.GetKey(KeyCode.UpArrow) && timeCount <= 0 && bulletsLeft < maxBullets)
        {
            Shoot();
            origin.color = Color.clear;
            timeCount = frecuency;
        }
        if (timeCount <= 0) origin.color = Color.white;
        if (timeCount < -20f) timeCount = -18;
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
