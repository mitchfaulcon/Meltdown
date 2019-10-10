using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositBin : InteractableObjectBase
{
    public ItemTypes type;
    public ItemTypes currentTrash;
    public ScoreController scoring;
    public TaskController taskControl;
    public GameObject correctAlert;
    public GameObject incorrectAlert;
    

    public override ItemTypes OnInteract()
    {
        scoring = FindObjectOfType<ScoreController>();
        // If the type of rubbish the player is holding is the same as the bin takes in, grant score, show the player they were correct
        if (currentTrash == type)
        {
            scoring.taskScored(ScoreController.Tasks.SORT_RUBBISH);
            correctAlert.SetActive(true);
            incorrectAlert.SetActive(false);
            Invoke("removeAlerts", 2);
        }
        // If the player deposits incorrect rubbish, tell the player they were wrong and hide popup after 2 seconds
        else
        {
            scoring.taskFailed(ScoreController.Tasks.SORT_RUBBISH);
            correctAlert.SetActive(false);
            incorrectAlert.SetActive(true);
            Invoke("removeAlerts", 2);
        }

        // Either way, mark the task as complete in the Task Controller and remove the rubbish from the players hand
        taskControl = FindObjectOfType<TaskController>();
        taskControl.taskComplete(TaskTypes.Rubbish);

        return ItemTypes.NONE;
    }

    public override bool CanInteract(ItemTypes heldItem)
    {
        // If the currently held item is a type of rubbish, then allow the player to interact with any of the bins
        currentTrash = heldItem;
        if (heldItem == ItemTypes.RubbishBag || heldItem == ItemTypes.BananaSkin || heldItem == ItemTypes.Recyclables)
        {
            InteractText = "Press J to deposit " + currentTrash.ToString();
            return true;
        }
        return false;
    }

    public void removeAlerts()
    {
        // Hide both correct and incorrect popup alerts
        correctAlert.SetActive(false);
        incorrectAlert.SetActive(false);
    }

}
