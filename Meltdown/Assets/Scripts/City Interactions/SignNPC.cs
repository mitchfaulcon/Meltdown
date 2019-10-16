using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignNPC : InteractableObjectBase
{
    public CityTaskController taskController;
    public CityScoreController scoreController;

    private CityCrowdNPC cityCrowdNPC;

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
        cityCrowdNPC = this.GetComponent<CityCrowdNPC>();
        InteractText = "Press J to give climate protester a sign";
    }

    public override ItemTypes OnInteract()
    {
        //Make sign they are holding visible
        this.gameObject.transform.Find("character").Find("Armature").Find("main").Find("chest").Find("shoulders").Find("armRight1").Find("armRight2").Find("handRight").Find("itemLeft").Find("ProtestSign").gameObject.SetActive(true);
        hasSign = true;
        cityCrowdNPC.animator.SetBool("holdingSign", true);

        //complete sign task
        taskController.taskComplete(TaskTypes.Sign);
    
        return ItemTypes.NONE;
    }
}
