using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndoorPlayerInteraction : PlayerInteraction
{
    public GameObject holdingLettuce;
    public GameObject holdingAvocado;
    public GameObject holdingTomato;
    public GameObject holdingSalad;
    public GameObject saladAlert;


    // Remove all item speech bubbles
    protected override void removeSpeechBubbles()
    {
        holdingLettuce.SetActive(false);
        holdingAvocado.SetActive(false);
        holdingSalad.SetActive(false);
        holdingTomato.SetActive(false);
        saladAlert.SetActive(false);
    }

    // Show currently held item from the kitchen
    protected override void setActiveBubble()
    {
        if (heldItem == ItemTypes.Tomatoes)
        {
            holdingTomato.SetActive(true);
        }
        else if (heldItem == ItemTypes.Lettuce)
        {
            holdingLettuce.SetActive(true);
        }
        else if (heldItem == ItemTypes.Avocado)
        {
            holdingAvocado.SetActive(true);
        }
        else if (heldItem == ItemTypes.Salad)
        {
            holdingSalad.SetActive(true);
            saladAlert.SetActive(true);
        }
    }
}
