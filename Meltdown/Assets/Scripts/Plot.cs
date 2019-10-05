using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : InteractableObjectBase
{
    private bool hasPlant = false;
    public bool watered = false;
    public ItemTypes plotType;
    public TaskController controller;
    public WateringCan can;
    public ScoreController scoring;

    private void Start()
    {
        controller = FindObjectOfType<TaskController>();
        can = FindObjectOfType<WateringCan>();
    }

    public override ItemTypes OnInteract()
    {
        if(hasPlant == false)
        {
            hasPlant = true;
            can.fill();
            InteractText = "Press J to Water";

        }
        else if (!watered)
        {
            watered = true;
            TaskTypes task = TaskTypes.Tree;
            if(plotType == ItemTypes.CarrotSeeds)
            {
                task = TaskTypes.Carrot;
            }
            else if(plotType == ItemTypes.PotatoSeeds)
            {
                task = TaskTypes.Potato;
            }
            else if (plotType == ItemTypes.TomatoSeeds)
            {
                task = TaskTypes.Tomato;
            }

            scoring = FindObjectOfType<ScoreController>();
            scoring.taskScored(0.3f);

            controller.taskComplete(task);

        }
        

        return ItemTypes.NONE;
    }

    public override bool CanInteract(ItemTypes heldItem)
    {   
        if(heldItem == plotType)
        {
            return !hasPlant;
        }
        else if(heldItem == ItemTypes.WaterBucket && hasPlant)
        {
            return !watered;
        }
        return false;
    }

}
