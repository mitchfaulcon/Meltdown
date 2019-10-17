using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeShop : ItemCollectorBase
{
    private bool playerHasBike = false;
    public override bool CanInteract(ItemTypes heldItem)
    {
        if (heldItem == ItemTypes.NONE)
        {
            return true;
        }
        else if (heldItem == ItemTypes.Bike)
        {
            InteractText = "Press J to return Bike";
            playerHasBike = true;
            return true;
        }
        return false;
    }

    public override ItemTypes OnInteract()
    {
        if (playerHasBike == true)
        {
            InteractText = "Press J to get Bike";
            return ItemTypes.NONE;
        }
        else
        {
            containsItem = false;
            //alert.SetActive(false);
            return item;
        }
    }

}
