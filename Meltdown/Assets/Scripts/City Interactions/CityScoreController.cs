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
        public const float SIGN = 0.07f;
        public const float SOLAR = 0.025f;
        public const float BIKE = 0.5f;
    }

    public Material treeMaterial;
    private readonly Color goodTreeColour = new Color(0.8f, 0.8f, 0.8f, 1f); //Normal green colour
    private readonly Color badTreeColour = new Color(0.635f, 0.318f, 0f, 1f); //Dark brown colour
    private Color targetColour;

    public Material lowPolyTreeMaterial;
    private readonly Color goodPolyTreeColour = new Color(0.125f, 0.467f, 0.039f, 1f); //Normal green colour
    private readonly Color badPolyTreeColour = new Color(0.361f, 0.192f, 0.051f, 1f); //Dark brown colour
    private Color targetPolyColour;

    private void Start()
    {
        
    }

    protected override void updateScenery()
    {
        ////Calculate the new colour as the value of the temperature between the bad & good colours
        //targetColour = (currentValue) * (badTreeColour) + (1 - currentValue) * (goodTreeColour);
        ////Smooth the colour change over 2 seconds
        //treeMaterial.color = Color.Lerp(treeMaterial.color, targetColour, Time.deltaTime / 2f);

        ////Do the same for the low poly trees
        //targetPolyColour = (currentValue) * (badPolyTreeColour) + (1 - currentValue) * (goodPolyTreeColour);
        //lowPolyTreeMaterial.color = Color.Lerp(lowPolyTreeMaterial.color, targetPolyColour, Time.deltaTime / 2f);



        //Perform code to increase smog opacity at lower bar level
    }
}
