using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishBin : InteractableObjectBase
{
    public bool hasRubbish = false;
    public int rubbishLevel = 0;
    public GameObject alert;

    public override ItemTypes OnInteract()
    {
        rubbishLevel--;
        Debug.Log("lowering rubbish level: " + rubbishLevel);
        if(rubbishLevel <= 0)
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

    public override bool CanInteract(ItemTypes heldItem)
    {   
        if(heldItem == ItemTypes.NONE && hasRubbish)
        {
            InteractText = "Press J to collect rubbish";
            return true;
        }
        return false;
    }

    public void fillBin()
    {
        rubbishLevel = 3;
        hasRubbish = true;
        alert.SetActive(true);
    }
}
