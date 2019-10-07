using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterButtonHandler : MonoBehaviour
{
    //Array of all continue buttons in order
    public Button[] continueButtons;

    // Update is called once per frame
    void Update()
    {
        //Check for 'Enter'
        if (Input.GetKeyDown("return"))
        {
            //Check each button & activate if it is enabled (visible to user)
            foreach (Button button in continueButtons)
            {
                if (button.isActiveAndEnabled)
                {
                    button.onClick.Invoke();
                    break;
                }
            }
        }
    }
}
