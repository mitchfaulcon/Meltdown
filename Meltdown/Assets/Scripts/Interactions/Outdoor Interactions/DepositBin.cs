using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositBin : InteractableObjectBase
{
    public ItemTypes type;
    public ItemTypes currentTrash;
    public OutdoorScoreController scoring;
    public TaskController taskControl;
    public AudioSource errorSound;
    

    public override ItemTypes OnInteract()
    {
        scoring = FindObjectOfType<OutdoorScoreController>();
        // If the type of rubbish the player is holding is the same as the bin takes in, grant score, show the player they were correct
        if (currentTrash == type)
        {
            scoring.taskScored(OutdoorScoreController.Tasks.SORT_RUBBISH);
            Invoke("removeAlerts", 2);
            PlayInteractSound();
        }
        // If the player deposits incorrect rubbish, tell the player they were wrong and hide popup after 2 seconds
        else
        {
            scoring.taskFailed(OutdoorScoreController.Tasks.SORT_RUBBISH);
            Invoke("removeAlerts", 2);
            if (GameSettings.sounds == true)
            {
                errorSound.Play();
            }
        }

        

        // Either way, mark the task as complete in the Task Controller and remove the rubbish from the players hand
        taskControl = FindObjectOfType<TaskController>();
        taskControl.taskComplete(TaskTypes.Rubbish);
        playSound();

        return ItemTypes.NONE;
    }

    public override bool CanInteract(ItemTypes heldItem)
    {
        // If the currently held item is a type of rubbish, then allow the player to interact with any of the bins
        currentTrash = heldItem;
        if (heldItem == ItemTypes.RubbishBag || heldItem == ItemTypes.BananaSkin || heldItem == ItemTypes.Recyclables)
        {
            InteractText = "Press J to deposit ";
            switch (heldItem)
            {
                case ItemTypes.RubbishBag: InteractText += "Chip Packet";
                    break;
                case ItemTypes.BananaSkin:
                    InteractText += "Banana Skin";
                    break;
                case ItemTypes.Recyclables:
                    InteractText += "Bottle";
                    break;
            }
            return true;
        }
        return false;
    }

    public void removeAlerts()
    {

    }

}
