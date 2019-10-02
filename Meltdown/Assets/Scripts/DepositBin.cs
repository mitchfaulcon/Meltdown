using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static ScoreController;

public class DepositBin : InteractableObjectBase
{
    public ItemTypes type;
    public ItemTypes currentTrash;
    public ScoreController scoring;
    

    public override ItemTypes OnInteract()
    {
        Debug.Log("Depositing: " + currentTrash);

        if (currentTrash == type)
        {
            scoring = FindObjectOfType<ScoreController>();
            scoring.taskScored(0.2f);
        }

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
