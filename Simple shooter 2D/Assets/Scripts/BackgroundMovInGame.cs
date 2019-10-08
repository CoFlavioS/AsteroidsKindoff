using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovInGame : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public Vector3 startPos;
    public float startScaleX = 19;
    public float startScaleY = 6;
    public RectTransform actual;
    public GameObject duplicatePos;
    public RectTransform duplicate;

    void Start()
    {
        startPos = transform.position;
        actual.sizeDelta = new Vector3(startScaleX, startScaleY);
        duplicate.sizeDelta = new Vector2(startScaleX, startScaleY);
        duplicatePos.transform.position = new Vector3(startScaleX, duplicatePos.transform.position.y, duplicatePos.transform.position.z);
    }

    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, startScaleX);
        transform.position = startPos + Vector3.left * newPos;
    }
}