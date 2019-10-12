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
    public AudioSource diggingSound;
    public AudioSource wateringSound;


    private void Start()
    {
        // Identify the Task Controller and Watering Can objects immediately
        controller = FindObjectOfType<TaskController>();
        can = FindObjectOfType<WateringCan>();
    }

    // Interact with a particular plot
    public override ItemTypes OnInteract()
    {
        // If there is no plant, plant a dirt pile and set the next interaction text to water
        if(hasPlant == false)
        {
            this.transform.Find("Dirt_Pile").gameObject.SetActive(true);
            if (GameSettings.sounds == true)
            {
                diggingSound.Play();
            }
            hasPlant = true;
            can.fill();
            InteractText = "Press J to Water";

        }
        // If it's not watered, water the plot to grow the plant
        else if (!watered)
        {
            watered = true;
            this.transform.Find("plant").gameObject.SetActive(true);
            if (GameSettings.sounds == true)
            {
                wateringSound.Play();
            }
            TaskTypes task = TaskTypes.Tree;

            // Grow the correct type of plant
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

            // Grant score, and complete the task
            scoring = FindObjectOfType<OutdoorScoreController>();
            scoring.taskScored(OutdoorScoreController.Tasks.PLANT);
            controller.taskComplete(task);
        }
        
        // Remove items from the player after interaction
        return ItemTypes.NONE;
    }

    // The player can interact if the plot is empty, or if a plant is there but needs watering
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
