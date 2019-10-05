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

    public void OpenMessagePanel(InteractableObjectBase item)
    {
        MessagePanel.SetActive(true);

        Text mpText = MessagePanel.transform.Find("Text").GetComponent<Text>();
        mpText.text = item.InteractText;


        mIsMessagePanelOpened = true;


    }

    public void OpenMessagePanel(string text)
    {
        MessagePanel.SetActive(true);

        Text mpText = MessagePanel.transform.Find("Text").GetComponent<Text>();
        mpText.text = text;


        mIsMessagePanelOpened = true;
    }

    public void CloseMessagePanel()
    {
        MessagePanel.SetActive(false);

        mIsMessagePanelOpened = false;
    }
}
