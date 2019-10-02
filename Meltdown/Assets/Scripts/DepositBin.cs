using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositBin : InteractableObjectBase
{
    public string type;
    public ItemTypes currentTrash;

    public override ItemTypes OnInteract()
    {
        Debug.Log("Depositing: " + currentTrash);
        return ItemTypes.NONE;
    }

    public override bool CanInteract(ItemTypes heldItem)
    {
        currentTrash = heldItem;
        if (heldItem == ItemTypes.RubbishBag || heldItem == ItemTypes.BananaSkin || heldItem == ItemTypes.Recyclables)
        {
            InteractText = "Press J to deposit " + heldItem;
            return true;
        }
        return false;
    }

}
