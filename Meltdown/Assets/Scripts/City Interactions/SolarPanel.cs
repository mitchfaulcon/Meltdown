using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanel : InteractableObjectBase
{
    private bool solarPanelSet = false;
    public ResourceCollector toolStore;

    public override bool CanInteract(ItemTypes item)
    {
        if(item == ItemTypes.Solar && !solarPanelSet)
        {
            return true;
        }
        else if(item == ItemTypes.Tools && solarPanelSet)
        {
            return true;
        }
        return false;
    }
    public override ItemTypes OnInteract()
    {
        if (!solarPanelSet)
        {
            solarPanelSet = true;
            toolStore.fill();
            this.GetComponent<MeshRenderer>().material.color = new Color(0.2683339f, 0.4018649f, 0.4245283f, 1.0f);
        }
        else
        {
            //have tick appear for task completion
            this.gameObject.SetActive(false);
            solarPanelSet = false;
            //complete solarPanel Tasks
        }
        return ItemTypes.NONE;
    }

    public void setupTask()
    {
        this.GetComponent<MeshRenderer>().material.color = new Color(0.2683339f, 0.4018649f, 0.4245283f, 0.1f);
        this.gameObject.SetActive(true);
    }
}
