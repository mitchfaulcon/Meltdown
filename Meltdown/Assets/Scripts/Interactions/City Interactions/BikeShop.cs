using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeShop : ItemCollectorBase
{
    public override bool CanInteract(ItemTypes heldItem)
    {
        if (heldItem == ItemTypes.NONE && containsItem)
        {
            return true;
        }
        return false;
    }

    public override ItemTypes OnInteract()
    {
        containsItem = false;
        alert.SetActive(false);
        if (GameSettings.sounds)
        {
            interactSound.Play();
        }
        return item;
    }

}
