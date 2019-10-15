using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignNPC : InteractableObjectBase
{
    public bool hasSign = false;
    public override bool CanInteract(ItemTypes item)
    {
        if(item == ItemTypes.Sign && !hasSign)
        {

            return true;
        }
        return false;
    }

    public override ItemTypes OnInteract()
    {
        hasSign = true;
        //make sign visible in NPC hand
        //complete sign task
        return ItemTypes.NONE;
    }
}
