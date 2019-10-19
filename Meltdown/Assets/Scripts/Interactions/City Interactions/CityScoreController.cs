using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CityScoreController : ScoreController
{
    protected new static readonly float DEFAULT_RATE = 0.003f;
    protected new static readonly float ONE_STAR_RATE = 0.001f;
    protected new static readonly float TWO_STAR_RATE = 0.003f;
    protected new static readonly float THREE_STAR_RATE = 0.005f;

    public struct Tasks
    {
        public const float SIGN = 0.08f;
        public const float SOLAR = 0.13f;
        public const float BIKE = 0.11f;
        public const float BIKE_FAILED = 0.05f;
    }

    private readonly float goodFogDensity = 0f;
    private readonly float badFogDensity = 0.035f;
    private float targetDensity;

    private void Start()
    {
        RenderSettings.fogDensity = badFogDensity;
        RenderSettings.fog = true; //Makes fog visible/enabled
    }

    protected override void updateScenery()
    {
        //Calculate the new density as the value of the temperature between the bad & good densities
        targetDensity = (currentValue) * (badFogDensity) + (1 - currentValue) * (goodFogDensity);

        //Smooth the density change over 2 seconds
        RenderSettings.fogDensity = Mathf.Lerp(RenderSettings.fogDensity, targetDensity, Time.deltaTime / 2f);
    }

    //Overload method to display bike failed popup at taxi instead of player
    public void taskFailed(float points, Transform taskLocation)
    {
        currentValue += points;

        DisplayPopup(points, false, taskLocation);
    }
}
