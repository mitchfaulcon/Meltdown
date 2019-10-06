using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    private readonly string SCORETEXT = "SCORE: ";

    public TextMeshProUGUI scoreDisplayText;

    // Start is called before the first frame update
    void Start()
    {
        float score = Score.GetInstance().GetPoints();
        string scoreText = SCORETEXT + score.ToString();
        scoreDisplayText.text = scoreText;
    }
}
