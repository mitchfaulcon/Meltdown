using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBox : InteractableObjectBase
{
    public bool hasSeeds = false;
    public ItemTypes seedType;
    public GameObject alert;

    //Player collects the seed, so remove seed from box and remove alert;
    public override ItemTypes OnInteract()
    {
        hasSeeds = false;
        alert.SetActive(false);
        return seedType;
    }

    //If player isn't holding anything, can collect a seed if task is active
    public override bool CanInteract(ItemTypes heldItem)
    {   
        if (heldItem == ItemTypes.NONE)
        {
            return hasSeeds;
        }
        return false;
    }

    //Add seeds to box and show the pop-up over the box
    public void fillSeedBox()
    {
        hasSeeds = true;
        alert.SetActive(true);
    }

}
