using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeNPC : InteractableObjectBase
{
    public CityTaskController taskController;
    CityBikeNPC npc;

    public OutdoorScoreController scoring;

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
        npc = this.GetComponent<CityBikeNPC>();
        npc.GiveBike();

        taskController.taskComplete(TaskTypes.Bike);

        return ItemTypes.NONE;
    }

    public void FailTask() {
        // Should also play fail sound along with fail speech bubble and remove points

        taskController.removeTask(TaskTypes.Bike);
    }
}
