using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaladNPC : ItemCollectorBase
{
    public ScoreController scoring;
    public IndoorTaskController taskControl;
    public override ItemTypes OnInteract()
    {
        interactSound.Play();
        scoring.taskScored(IndoorScoreController.Tasks.SALAD);
        //alert.SetActive(false);
        taskControl.removeSaladTask();
        return ItemTypes.NONE;
    }

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
        //alert.SetActive(true);
    }
}
