using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMov : MonoBehaviour
{
    public GameObject player;

    public float moveSpeed = 700f;

    float movement = 0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) movement = -1;
        else if (Input.GetKey(KeyCode.RightArrow)) movement = 1;
        else movement = 0;
    }

    private void FixedUpdate()
    {
        transform.RotateAround(player.transform.position, Vector3.forward, movement * Time.fixedDeltaTime * -moveSpeed);
    }
}
