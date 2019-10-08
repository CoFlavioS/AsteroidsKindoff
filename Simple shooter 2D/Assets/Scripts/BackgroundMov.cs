using System.Collections.Generic;
using UnityEngine;

public class BackgroundMov : MonoBehaviour
{
    public float scrollSpeed = 32f;
    public Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, 590f);
        transform.position = startPos + Vector3.left * newPos;
    }
}
