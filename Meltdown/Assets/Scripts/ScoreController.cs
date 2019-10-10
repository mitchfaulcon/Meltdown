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
   
    private static readonly float DEFAULT_RATE = 0.003f;
    
    private float increaseRate = DEFAULT_RATE;
    public TextMeshProUGUI scoreText;
    public struct Tasks
    {
        public const float SORT_RUBBISH = 0.07f;
        public const float PLANT = 0.06f;
    }
    // Update is called once per frame
    void Update()
    {
        currentValue += increaseRate * Time.deltaTime;
        //Fix value between 0 and 1
        currentValue = Mathf.Clamp(currentValue, 0f, 1f);

        slider.value = currentValue;
        barImage.fillAmount = currentValue;
        
        float newRate = DEFAULT_RATE;
        if (1 - currentValue > ScoreDisplay.THREESTARTHRESHOLD/10000f) {
            newRate += 0.005f;
        } else if (1 - currentValue > ScoreDisplay.TWOSTARTHRESHOLD/10000f) {
            newRate += 0.003f;
        } else if (1 - currentValue > ScoreDisplay.ONESTARTHRESHOLD/10000f) {
            newRate += 0.001f;
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
