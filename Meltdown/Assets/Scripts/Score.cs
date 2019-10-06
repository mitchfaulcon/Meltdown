using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    private static readonly Score instance = new Score();
    private float points;

    private Score()
    {

    }

    public static Score GetInstance()
    {
        return instance;
    }

    public void SetPoints(float score)
    {
        score = (1 - score) * 100;

        //Scale up score & round off decimals
        score *= 100;
        score = Mathf.Round(score);

        points = score;
    }

    public float GetPoints()
    {
        return points;
    }
}
