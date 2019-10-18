using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FOG_SCRIPT : ScoreController
{
    private readonly float goodFogDensity = 0f;
    private readonly float badFogDensity = 0.05f;
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
}
