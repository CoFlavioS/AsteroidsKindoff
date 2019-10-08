using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData{

    public float score1;
    public float score2;
    public float score3;
    public float score4;
    public float score5;

    public PlayerData(float one, float two, float three, float four, float five)
    {
        score1 = one;
        score2 = two;
        score3 = three;
        score4 = four;
        score5 = five;
    }
}
