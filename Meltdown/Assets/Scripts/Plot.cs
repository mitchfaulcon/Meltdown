using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : InteractableObjectBase
{
    private bool hasPlant = false;
    public ItemTypes plotType; 

    public override ItemTypes OnInteract()
    {
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
