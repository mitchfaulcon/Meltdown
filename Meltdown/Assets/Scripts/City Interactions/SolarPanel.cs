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
            //set panel to fully opaque
        }
        else
        {
            //have tick appear for task completion
            this.gameObject.SetActive(false);
            solarPanelSet = false;
            //complete solarPanel Tasks
        }
    }

    public void setupTask()
    {
        //set object back to transparent
        this.gameObject.SetActive(true);
    }
}
