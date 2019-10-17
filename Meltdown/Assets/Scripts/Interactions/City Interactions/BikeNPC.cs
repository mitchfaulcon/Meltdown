using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeNPC : InteractableObjectBase
{
    CityTaskController taskController;
    public override bool CanInteract(ItemTypes item)
    {
        if(item == ItemTypes.Bike)
        {
            return true;
        }
        return false;
    }

    public override ItemTypes OnInteract()
    {
        //get NPC to change course and leave off screen
        //Complete Bike task
        taskController.taskComplete(TaskTypes.Bike);

        return ItemTypes.NONE;
    }
}
