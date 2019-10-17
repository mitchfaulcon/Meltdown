using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignStation : InteractableObjectBase
{
    public override bool CanInteract(ItemTypes item)
    {
        if(item == ItemTypes.Supplies)
        {
            return true;
        }
        return false;
    }

    public override ItemTypes OnInteract()
    {
        return ItemTypes.Sign;
    }
}
