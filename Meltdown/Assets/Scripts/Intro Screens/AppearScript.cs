using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppearScript : MonoBehaviour
{
    public GameObject continueButton;

    // Start is called before the first frame update
    // Hide the continue button for 2 seconds while the spin in animation plays
    void Start()
    {
        continueButton.SetActive(false);
        StartCoroutine(WaitForTwoSeconds());
    }

    IEnumerator WaitForTwoSeconds()
    {
        yield return new WaitForSeconds(2);
        continueButton.SetActive(true);
    }
}
