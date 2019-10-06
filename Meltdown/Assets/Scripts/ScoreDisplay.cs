using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    private readonly string SCORETEXT = "SCORE: ";

    private readonly string ZEROSTARCOMMENT = "You reduced the temeperature rise by only ";
    private readonly string ONESTARCOMMENT = "Not bad! You reduced the predicted temperature rise by ";
    private readonly string TWOSTARCOMMENT = "Well done! You reduced the predicted temperature rise by ";
    private readonly string THREESTARCOMMENT = "Excellent! You reduced the predicted temperature rise by ";

    private readonly float ONESTARTHRESHOLD = 1000;
    private readonly float TWOSTARTHRESHOLD = 4000;
    private readonly float THREESTARTHRESHOLD = 8000;

    public TextMeshProUGUI scoreDisplayText;
    public TextMeshProUGUI commentDisplayText;

    // Start is called before the first frame update
    void Start()
    {
        float score = Score.GetInstance().GetPoints();

        SetScoreText(score);

        CalculateStars(score);

        SetComment(score);
    }

    private void SetScoreText(float score)
    {
        string scoreText = SCORETEXT + score.ToString();
        scoreDisplayText.text = scoreText;
    }


    private void CalculateStars(float score)
    {

    }

    private void SetComment(float score)
    {
        if (score >= THREESTARTHRESHOLD)
        {
            commentDisplayText.text = THREESTARCOMMENT;
        } else if (score >= TWOSTARTHRESHOLD)
        {
            commentDisplayText.text = TWOSTARCOMMENT;
        } else if (score >= ONESTARTHRESHOLD)
        {
            commentDisplayText.text = ONESTARCOMMENT;
        } else
        {
            commentDisplayText.text = ZEROSTARCOMMENT;
        }

        string commentSuffix = (score / 100).ToString() + "%";
        commentDisplayText.text += commentSuffix;
    }
}
