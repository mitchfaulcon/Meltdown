using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject MessagePanel;
    private bool mIsMessagePanelOpened = false;


    public bool IsMessagePanelOpened
    {
        get { return mIsMessagePanelOpened; }
    }

    // Display interaction message panel with reference to an item's interation text
    public void OpenMessagePanel(InteractableObjectBase item)
    {
        MessagePanel.SetActive(true);

        Text mpText = MessagePanel.transform.Find("Text").GetComponent<Text>();
        mpText.text = item.InteractText;

        mIsMessagePanelOpened = true;
    }

    // Display interaction message panel with reference to given interaction text
    public void OpenMessagePanel(string text)
    {
        MessagePanel.SetActive(true);

        Text mpText = MessagePanel.transform.Find("Text").GetComponent<Text>();
        mpText.text = text;


        mIsMessagePanelOpened = true;
    }

    // Close interaction message panel
    public void CloseMessagePanel()
    {
        MessagePanel.SetActive(false);

        mIsMessagePanelOpened = false;
    }
}
