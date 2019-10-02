using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishBin : InteractableObjectBase
{
    public bool hasRubbish = true;
    public int rubbishLevel = 3;

    public override ItemTypes OnInteract()
    {
        InteractText = "Press J to collect rubbish";
        rubbishLevel--;
        Debug.Log("lowering rubbish level: " + rubbishLevel);
        if(rubbishLevel == 0)
        {
            hasRubbish = false;
        }
        return ItemTypes.RubbishBag;
    }

    public override bool CanInteract(ItemTypes heldItem)
    {   
        if(heldItem == ItemTypes.NONE)
        {
            return hasRubbish;
        }
        return false;
    }

    public void fillBin()
    {
        rubbishLevel = 3;
        hasRubbish = true;
    }
}
