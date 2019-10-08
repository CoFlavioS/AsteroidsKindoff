using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float baseLife = 3f;
    public float life;
    public float damage = 1f;
    public GameObject death;
    public Color full;
    public Color half;
    public Color last;

    public float points;
    public TextMeshProUGUI pointsShow;
    public RectTransform pointsPosition;
    private PlayerData scores;
    public Animator animator;

    public float frecuency = 2f;
    private float timeCount1 = 0;

    private void Start()
    {
        scores = SaveData.LoadPlayer();
        points = 0;
        life = baseLife;
        animator.SetFloat("life", life);
        timeCount1 = frecuency;
        pointsPosition.localPosition = new Vector3(0, 452, 0);
    }

    private void Update()
    {
        pointsShow.text = points.ToString();

        timeCount1 -= Time.deltaTime;

        if (timeCount1 < -20f) timeCount1 = -18;
    }
    void TakeDamage(float damage)
    {
        life -= damage;

        if (life <= 0)
        {
            Death();
        }

        animator.SetFloat("life", life);
    }

    void Death()
    {
        OrderScores(scores, points);
        SaveData.SavePlayer(scores);
        pointsPosition.localPosition = new Vector3(0, 64, 0);
        death.SetActive(true);
        Time.timeScale = 0f;
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Meteorite meteorite = collision.gameObject.GetComponent<Meteorite>();

        //Debug.Log(collision.gameObject.name);

        if (meteorite != null && timeCount1 <= 0)
        {
            TakeDamage(damage);
            timeCount1 = frecuency;
        }
    }

    private PlayerData OrderScores(PlayerData scores, float newScore)
    {
        float j;

        if (newScore > scores.score1)
        {
            j = scores.score1;
            scores.score1 = newScore;
            newScore = j;
        }
        if (newScore > scores.score2)
        {
            j = scores.score2;
            scores.score2 = newScore;
            newScore = j;
        }
        if (newScore > scores.score3)
        {
            j = scores.score3;
            scores.score3 = newScore;
            newScore = j;
        }
        if (newScore > scores.score4)
        {
            j = scores.score4;
            scores.score4 = newScore;
            newScore = j;
        }
        if (newScore > scores.score5)
        {
            j = scores.score5;
            scores.score5 = newScore;
            newScore = j;
        }

        return scores;
    }
}