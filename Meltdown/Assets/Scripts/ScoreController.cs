using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
    {

    public Slider slider;
    private float currentValue = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        currentValue = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        currentValue -= 0.0003f;
        slider.value = currentValue;
    }

    public void taskScored(float points)
    {
        Debug.Log("Correct bin, scoring points");
        currentValue += points;
    }
}
