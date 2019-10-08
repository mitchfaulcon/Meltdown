using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private enum ScoreLevel { NONE, ONE, TWO, THREE }

    private readonly string SCORETEXT = "SCORE: ";

    private readonly string ZEROSTARCOMMENT = "You reduced the temeperature rise by only ";
    private readonly string ONESTARCOMMENT = "Not bad! You reduced the predicted temperature rise by ";
    private readonly string TWOSTARCOMMENT = "Well done! You reduced the predicted temperature rise by ";
    private readonly string THREESTARCOMMENT = "Excellent! You reduced the predicted temperature rise by ";

    //Different score thresholds - change to whatever neccesary
    public static readonly float ONESTARTHRESHOLD = 2640;
    public static readonly float TWOSTARTHRESHOLD = 4600;
    public static readonly float THREESTARTHRESHOLD = 6400;

    public TextMeshProUGUI scoreDisplayText;
    public TextMeshProUGUI commentDisplayText;
    public Image oneStar;
    public Image twoStar;
    public Image threeStar;

    public bool highScore = false;

    // Start is called before the first frame update
    void Start()
    {
        //Get score from level
        float score = Score.GetInstance().GetPoints();

        //Calculate which enum value score corresponds to
        ScoreLevel level = CalculateLevel(score);

        //Display score & correct comment
        SetScoreText(score);
        SetComment(level, score);

        // Update HighScoreManager to save potential highscore
        highScore = HighScoreManager.recieveNewScore((int)score);

        //Initially hide all stars
        oneStar.enabled = false;
        twoStar.enabled = false;
        threeStar.enabled = false;
        //Display correct no. of stars
        SetStars(level);
    }

    private void SetScoreText(float score)
    {
        //Add score to end of text
        string scoreText = SCORETEXT + score.ToString();
        scoreDisplayText.text = scoreText;
    }

    private ScoreLevel CalculateLevel(float score)
    {
        if (score >= THREESTARTHRESHOLD)
        {
            return ScoreLevel.THREE;
        }
        else if (score >= TWOSTARTHRESHOLD)
        {
            return ScoreLevel.TWO;
        }
        else if (score >= ONESTARTHRESHOLD)
        {
            return ScoreLevel.ONE;
        }
        else
        {
            return ScoreLevel.NONE;
        }
    }

    private void SetComment(ScoreLevel level, float score)
    {
        switch (level)
        {
            case ScoreLevel.NONE:
                commentDisplayText.text = ZEROSTARCOMMENT;
                break;
            case ScoreLevel.ONE:
                commentDisplayText.text = ONESTARCOMMENT;
                break;
            case ScoreLevel.TWO:
                commentDisplayText.text = TWOSTARCOMMENT;
                break;
            case ScoreLevel.THREE:
                commentDisplayText.text = THREESTARCOMMENT;
                break;
        }

        //Convert score back to percentage to display
        string commentSuffix = (score / 100).ToString() + "%";
        commentDisplayText.text += commentSuffix;
    }

    private void SetStars(ScoreLevel level)
    {
        switch (level)
        {
            case ScoreLevel.NONE:
                break;
            case ScoreLevel.ONE:
                //Enable first star
                oneStar.enabled = true;
                break;
            case ScoreLevel.TWO:
                //Enable second star & call this method again for first star
                twoStar.enabled = true;
                SetStars(ScoreLevel.ONE);
                break;
            case ScoreLevel.THREE:
                //Enable third star & call this method again for second star
                threeStar.enabled = true;
                SetStars(ScoreLevel.TWO);
                break;
        }
    }
}
