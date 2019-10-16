using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OutdoorScoreController : ScoreController
    {
    protected new static readonly float DEFAULT_RATE = 0.003f;
    protected new static readonly float ONE_STAR_RATE = 0.001f;
    protected new static readonly float TWO_STAR_RATE = 0.003f;
    protected new static readonly float THREE_STAR_RATE = 0.005f;

    public struct Tasks
    {
        public const float SORT_RUBBISH = 0.07f;
        public const float PLANT = 0.06f;
    }

    public Material treeMaterial;
    private readonly Color goodTreeColour = new Color(0.8f, 0.8f, 0.8f, 1f); //Normal green colour
    private readonly Color badTreeColour = new Color(0.635f, 0.318f, 0f, 1f); //Dark brown colour
    private Color targetColour;
    
    private void Start()
    {
        targetColour = badTreeColour;
    }

    // Update is called once per frame

    protected override void updateScenery()
    {
        ////Calculate the new colour as the value of the temperature between the bad & good colours
        targetColour = (currentValue) * (badTreeColour) + (1 - currentValue) * (goodTreeColour);

        ////Smooth the colour change over 2 seconds
        treeMaterial.color = Color.Lerp(treeMaterial.color, targetColour, Time.deltaTime / 2f);
    }
}
