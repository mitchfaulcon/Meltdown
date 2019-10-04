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
        Debug.Log("Depositing: " + currentTrash);

        if (currentTrash == type)
        {
            scoring = FindObjectOfType<ScoreController>();
            scoring.taskScored(0.2f);
            correctAlert.SetActive(true);
            incorrectAlert.SetActive(false);
            Invoke("removeAlerts", 2);
        }
        else
        {
            correctAlert.SetActive(false);
            incorrectAlert.SetActive(true);
            Invoke("removeAlerts", 2);
        }

        taskControl = FindObjectOfType<TaskController>();
        taskControl.taskComplete(TaskTypes.Rubbish);

        return ItemTypes.NONE;
    }

    public override bool CanInteract(ItemTypes heldItem)
    {
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
        correctAlert.SetActive(false);
        incorrectAlert.SetActive(false);
    }

}
