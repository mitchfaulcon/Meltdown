using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleItem : InteractableObjectBase
{
    public bool on;
    private ItemTypes playerHolding;
    public bool isLight;
    public TaskTypes task;
    public TaskController taskControl;
    public IndoorScoreController scoring;

    // Start is called before the first frame update
    private void Start()
    {
        taskControl = FindObjectOfType<TaskController>();
    }

    public override ItemTypes OnInteract()
    {
        scoring = FindObjectOfType<IndoorScoreController>();

        on = false;
        PlayInteractSound();
 
        if (isLight)
        {
            //turn off the light
            this.transform.Find("Light").gameObject.SetActive(false);
        }
        else
        {
            // Turn off the water
            this.transform.Find("Water").gameObject.SetActive(false);
            this.transform.Find("SinkWater").gameObject.SetActive(false);
        }

        taskControl.taskComplete(task);
        scoring.taskScored(IndoorScoreController.Tasks.TOGGLE);

        return playerHolding;
    }

    // Update is called once per frame
    public override bool CanInteract(ItemTypes item)
    {
        playerHolding = item;
        return on;
    }

    // Allow the NPC to turn these toggles on
    public void Activate()
    {
        on = true;
        if(task == TaskTypes.Tap)
        {
            this.transform.Find("Water").gameObject.SetActive(true);
            this.transform.Find("SinkWater").gameObject.SetActive(true);
        }
        else
        {
            this.transform.Find("Light").gameObject.SetActive(true);

        }
    }
}
