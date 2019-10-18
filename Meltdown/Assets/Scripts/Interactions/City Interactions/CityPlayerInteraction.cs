using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityPlayerInteraction : PlayerInteraction
{
    public GameObject holdingBike;
    public GameObject holdingTools;
    public GameObject holdingSolar;
    public GameObject holdingSignMaterials;
    public GameObject holdingSign;


    // Remove all item speech bubbles
    protected override void removeSpeechBubbles()
    {
        holdingBike.SetActive(false);
        holdingTools.SetActive(false);
        holdingSolar.SetActive(false);
        holdingSignMaterials.SetActive(false);
        holdingSign.SetActive(false);
    }

    protected override void setActiveBubble()
    {
        if (heldItem == ItemTypes.Bike)
        {
            holdingBike.SetActive(true);
        }
        else if (heldItem == ItemTypes.Tools)
        {
            holdingTools.SetActive(true);
        }
        else if (heldItem == ItemTypes.Solar)
        {
            holdingSolar.SetActive(true);
        }
        else if (heldItem == ItemTypes.Supplies)
        {
            holdingSignMaterials.SetActive(true);
        }
        else if (heldItem == ItemTypes.Sign)
        {
            holdingSign.SetActive(true);
        }
    }

    public void setItem(ItemTypes item)
    {
        if(heldItem == ItemTypes.Bike)
        {
            heldItem = item;
            removeSpeechBubbles();
            setActiveBubble();
        }
    }
}
