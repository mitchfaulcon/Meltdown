using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : InteractableObjectBase
{
    private bool hasPlant = false;
    public bool watered = false;
    public ItemTypes plotType; 

    public override ItemTypes OnInteract()
    {
        if(hasPlant == false)
        {
            hasPlant = true;
        }
        else if (!watered)
        {
            watered = true;
        }
        

        return ItemTypes.NONE;
    }

    public override bool CanInteract(ItemTypes heldItem)
    {   
        if(heldItem == plotType)
        {
            return !hasPlant;
        }
        else if(heldItem == ItemTypes.WaterBucket && hasPlant)
        {
            return !watered;
        }
        return false;
    }

}
