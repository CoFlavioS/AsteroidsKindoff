using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MeteoriteSpawner : MonoBehaviour
{
    private int rand;
    private Vector2 spawnedPosition;
    public Quaternion spawnedRotation;
    public GameObject meteoritePrefab;
    public float angle;
    public Vector2 destinyPosition;
    private GameObject[] gos;
    public int quantity = 1;
    private int i;
    public TextMeshProUGUI round;

    private void Start()
    {
        quantity = 1;
    }

    void Update()
    {
        gos = GameObject.FindGameObjectsWithTag("Enemies");
        if (gos.Length <= 0)
        {
            round.text = "Round " + quantity;
            for (i = quantity; i>0; i--)SpawnMeteorite();
            quantity++;
        }
    }

    Vector3 SelectOrigin()
    {
        rand = Random.Range(0,4);
        Vector3 p = new Vector3(0,0,0);

        switch (rand)
        {
            case 0:
                p = new Vector3(15f,Random.Range(-4f, 4f), 0);
                break;
            case 1:
                p = new Vector3(-15f, Random.Range(-4f, 4f), 0);
                break;
            case 2:
                p = new Vector3(Random.Range(-8f, 8f), 10f, 0);
                break;
            case 3:
                p = new Vector3(Random.Range(-8f, 8f), -10f, 0);
                break;
        }

        return p;
    }

    Vector2 SelectDestiny()
    {
        return new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f)); ;
    }

    float RotationAngle(Vector2 a, Vector2 b)
    {
        float angle;
        //Vector2 c = new Vector2(b.x, a.y);
        float dac = Mathf.Sqrt(Mathf.Pow((b.x - a.x), 2) + Mathf.Pow((a.y - a.y), 2));
        float dab = Mathf.Sqrt(Mathf.Pow((b.x - a.x), 2) + Mathf.Pow((b.y - a.y), 2));

        angle = Mathf.Acos(dac/dab);

        return angle * (180/Mathf.PI);
    }

    void SpawnMeteorite()
    {
        spawnedPosition = SelectOrigin();
        destinyPosition = SelectDestiny();
        angle = RotationAngle(spawnedPosition, destinyPosition);
        if (spawnedPosition.y == -10 && spawnedPosition.x > destinyPosition.x) spawnedRotation = Quaternion.Euler(0, 0, -angle + 180);
        else if (spawnedPosition.x == -15 && spawnedPosition.y > destinyPosition.y) spawnedRotation = Quaternion.Euler(0, 0, -angle);
        else if (spawnedPosition.x == 15 && spawnedPosition.y < destinyPosition.y) spawnedRotation = Quaternion.Euler(0, 0, -angle + 180);
        else if (spawnedPosition.x == 15 && spawnedPosition.y > destinyPosition.y) spawnedRotation = Quaternion.Euler(0, 0, angle + 180);
        else if (spawnedPosition.y == 10 && spawnedPosition.x > destinyPosition.x) spawnedRotation = Quaternion.Euler(0, 0, angle + 180);
        else if (spawnedPosition.y == 10 && spawnedPosition.x < destinyPosition.x) spawnedRotation = Quaternion.Euler(0, 0, -angle);
        else spawnedRotation = Quaternion.Euler(0, 0, angle);
        Instantiate(meteoritePrefab, spawnedPosition, spawnedRotation);
        Debug.DrawLine(spawnedPosition, destinyPosition, Color.red, 20f);
    }
}
