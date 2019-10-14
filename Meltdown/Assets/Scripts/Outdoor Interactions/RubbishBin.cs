using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishBin : InteractableObjectBase
{
    public bool hasRubbish = false;
    public int rubbishLevel = 0;
    public GameObject alert;

    // Randomly give rubbish item to player, decrease rubbish level in the bin
    public override ItemTypes OnInteract()
    {
        rubbishLevel--;

        PlayInteractSound();

        // Remove popup alert if bin is empty
        if (rubbishLevel <= 0)
        {
            hasRubbish = false;
            alert.SetActive(false);
        }

        // Randomly decide on rubbish type
        int rand = Random.Range(1,4);
        if(rand == 1)
        {
            return ItemTypes.RubbishBag;
        }
        else if(rand == 2)
        {
            return ItemTypes.Recyclables;
        }
        else
        {
            return ItemTypes.BananaSkin;
        }
        
    }

    // The player can interact with the bin if it has rubbish and they are not carrying anything
    public override bool CanInteract(ItemTypes heldItem)
    {   
        if(heldItem == ItemTypes.NONE && hasRubbish)
        {
            // Set the interact prompt text
            InteractText = "Press J to collect Rubbish";
            return true;
        }
        return false;
    }

    // Setup bin for task, increase rubbish level by 3 and show the player a popup alert
    public void fillBin()
    {
        rubbishLevel = 3;
        hasRubbish = true;
        alert.SetActive(true);
    }
}
