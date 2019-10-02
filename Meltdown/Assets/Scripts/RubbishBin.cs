using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishBin : InteractableObjectBase
{
    public bool hasRubbish = true;
    public int rubbishLevel = 3;

    public override void OnInteract()
    {
        InteractText = "Press J to turn collect rubbish";
        rubbishLevel--;
        Debug.Log("lowering rubbish level");
        if(rubbishLevel == 0)
        {
            hasRubbish = false;
        }
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
