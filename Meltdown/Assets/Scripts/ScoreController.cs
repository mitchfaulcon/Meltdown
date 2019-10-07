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
    public TextMeshProUGUI scoreText;

    // Update is called once per frame
    void Update()
    {
        currentValue += 0.022f * Time.deltaTime;
        //Fix value between 0 and 1
        currentValue = Mathf.Clamp(currentValue, 0f, 1f);

        slider.value = currentValue;
        barImage.fillAmount = currentValue;
        Score.GetInstance().SetPoints(currentValue);
        scoreText.text = Score.GetInstance().GetPoints().ToString();
    }

    public void taskScored(float points)
    {
        currentValue -= points;
    }
}
