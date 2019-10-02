using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : InteractableObjectBase
{
    private bool hasPlant = false;
    private ItemTypes plotType;

    public override ItemTypes OnInteract()
    {
        InteractText = "Press J to plant Potato seeds";
        hasPlant = true;

        return ItemTypes.NONE;
    }

    public override bool CanInteract(ItemTypes heldItem)
    {   
        if(heldItem == plotType)
        {
            return !hasPlant;
        }
        return false;
    }

}
