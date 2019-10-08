using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundManager : MonoBehaviour
{
    public float yLimit = 5f;
    private float xLimit;

    private void Awake()
    {
        yLimit = 5f;
        xLimit = Camera.main.aspect * Camera.main.orthographicSize;

        if (gameObject.tag == "Enemies" || gameObject.tag == "Bullet")
        {
            yLimit += 0.5f;
            xLimit += 1f;
        }
    }
    private void Update()
    {
        if (transform.position.x >= xLimit) transform.position = new Vector3(-transform.position.x + 0.2f,transform.position.y,0);
        if (transform.position.y >= yLimit) transform.position = new Vector3(transform.position.x, -transform.position.y + 0.2f, 0);
        if (transform.position.x <= -xLimit) transform.position = new Vector3(-transform.position.x - 0.2f, transform.position.y, 0);
        if (transform.position.y <= -yLimit) transform.position = new Vector3(transform.position.x, -transform.position.y - 0.2f, 0);
    }
}
