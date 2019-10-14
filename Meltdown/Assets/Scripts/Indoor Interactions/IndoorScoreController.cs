using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IndoorScoreController : ScoreController
{
    protected new static readonly float DEFAULT_RATE = 0.003f;
    protected new static readonly float ONE_STAR_RATE = 0.001f;
    protected new static readonly float TWO_STAR_RATE = 0.003f;
    protected new static readonly float THREE_STAR_RATE = 0.005f;

    public struct Tasks
    {
        public const float SALAD = 0.07f;
        public const float TOGGLE = 0.05f;
    }

    private void Start()
    {

    }

    protected override void updateScenery()
    {

    }
}
