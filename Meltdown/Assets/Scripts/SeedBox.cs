using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBox : InteractableObjectBase
{
    public bool hasSeeds = false;
    public ItemTypes seedType;
    public GameObject alert;

    public override ItemTypes OnInteract()
    {
        hasSeeds = false;
        alert.SetActive(false);
        return seedType;
    }

    public override bool CanInteract(ItemTypes heldItem)
    {   
        if (heldItem == ItemTypes.NONE)
        {
            return hasSeeds;
        }
        return false;
    }

    public void fillSeedBox()
    {
        hasSeeds = true;
        alert.SetActive(true);
    }

}
