using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreController : MonoBehaviour
    {

    public Slider slider;
    private float currentValue = 1f;
    public Image barImage;
   
    private static readonly float DEFAULT_RATE = 0.02f;
    
    private float increaseRate = DEFAULT_RATE;
    public TextMeshProUGUI scoreText;

    // Update is called once per frame
    void Update()
    {
        currentValue += increaseRate * Time.deltaTime;
        //Fix value between 0 and 1
        currentValue = Mathf.Clamp(currentValue, 0f, 1f);

        slider.value = currentValue;
        barImage.fillAmount = currentValue;
        
        float newRate = DEFAULT_RATE;
        if (currentValue > ScoreDisplay.THREESTARTHRESHOLD/1000) {
            newRate += 0.03f;
        } else if (currentValue > ScoreDisplay.TWOSTARTHRESHOLD/1000) {
            newRate += 0.02f;
        } else if (currentValue > ScoreDisplay.ONESTARTHRESHOLD/1000) {
            newRate += 0.01f;
        }
        increaseRate = newRate;
        Score.GetInstance().SetPoints(currentValue);
        scoreText.text = Score.GetInstance().GetPoints().ToString();
    }


    public void taskScored(float points)
    {
        currentValue -= points;
    }

    public void taskFailed(float points)
    {
        currentValue += points;
    }
}
