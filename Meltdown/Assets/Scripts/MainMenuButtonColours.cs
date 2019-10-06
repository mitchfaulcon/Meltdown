using UnityEngine;
using TMPro;

public class MainMenuButtonColours : MonoBehaviour
{

    public TextMeshProUGUI buttonText;

    private readonly Color normalColour = new Color(0f,0f,0f); //Black
    private readonly Color hoverColour = new Color(0.5f, 0.5f, 0.5f);
    
    //Initialise button text colour
    private void Start()
    {
        buttonText.color = normalColour;
    }

    //Reset colour when button becomes visible (changing between menu scenes)
    private void OnEnable()
    {
        buttonText.color = normalColour;
    }

    //Change to hover colour when mouse enters button
    public void OnMouseEnter()
    {
        buttonText.color = hoverColour;
    }

    //Change back to normal colour when mouse leaves button
    public void OnMouseExit()
    {
        buttonText.color = normalColour;
    }
}
