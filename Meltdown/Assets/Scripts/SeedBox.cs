using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBox : InteractableObjectBase
{
    private bool hasSeeds = false;
    public ItemTypes seedType; 

    public override ItemTypes OnInteract()
    {
        hasSeeds = false;
        return seedType;
    }

    public override bool CanInteract(ItemTypes heldItem)
    {   
        if(heldItem == ItemTypes.NONE)
        {
            return hasSeeds;
        }
        return false;
    }

    public void fillSeedBox()
    {
        hasSeeds = true;
    }

}
