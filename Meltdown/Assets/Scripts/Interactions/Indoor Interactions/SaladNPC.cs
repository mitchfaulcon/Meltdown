using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaladNPC : ItemCollectorBase
{
    public ScoreController scoring;
    public IndoorTaskController taskControl;

    // Allow the player to give the NPC their held salad item
    public override ItemTypes OnInteract()
    {
        PlayInteractSound();
        scoring.taskScored(IndoorScoreController.Tasks.SALAD);
        taskControl.removeSaladTask();
        return ItemTypes.NONE;
    }

    // The player can only interact with the NPC if they are holding a salad
    public override bool CanInteract(ItemTypes item)
    {
        if(item == ItemTypes.Salad)
        {
            return true;
        }
        return false;
    }

    public void readyForSalad()
    {

    }
}
