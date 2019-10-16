using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignNPC : InteractableObjectBase
{
    public CityTaskController taskController;
    public CityScoreController scoreController;

    public bool hasSign = false;
    public override bool CanInteract(ItemTypes item)
    {
        if(item == ItemTypes.Sign && !hasSign)
        {
            return true;
        }
        return false;
    }

    public void Start()
    {
        taskController = GameObject.FindObjectOfType<CityTaskController>();
        scoreController = GameObject.FindObjectOfType<CityScoreController>();
    }

    public override ItemTypes OnInteract()
    {
        //make sign visible in NPC hand
        hasSign = true;

        //complete sign task
        taskController.taskComplete(TaskTypes.Sign);
    
        return ItemTypes.NONE;
    }
}
