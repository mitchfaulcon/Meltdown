using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanel : InteractableObjectBase
{
    private bool solarPanelSet = false;
    public ResourceCollector toolStore;

    public CityTaskController taskController;
    public AudioSource buildSound;
    public AudioSource baseSound;
    public GameObject[] truckSolarPanels;
    private int activePanels = 0;

    public override bool CanInteract(ItemTypes item)
    {
        if(item == ItemTypes.Solar && !solarPanelSet)
        {
            interactSound = baseSound;
            return true;
        }
        else if(item == ItemTypes.Tools && solarPanelSet)
        {
            interactSound = buildSound;
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
            Component[] panels = this.GetComponentsInChildren<MeshRenderer>();
            
            foreach (Component panel in panels)
            {
                ((MeshRenderer)panel).material.color = new Color(0.2683339f, 0.4018649f, 0.4245283f, 1.0f);
            }

        }
        else
        {
            //have tick appear for task completion
            this.gameObject.SetActive(false);
            this.truckSolarPanels[activePanels].SetActive(true);
            activePanels++;
            solarPanelSet = false;
            
            //complete solarPanel Tasks
            taskController.taskComplete(TaskTypes.Solar);
        }
        return ItemTypes.NONE;
    }

    public void setupTask()
    {
        this.gameObject.SetActive(true);
        Component[] panels = this.GetComponentsInChildren<MeshRenderer>();
        foreach (Component panel in panels)
        {
           ((MeshRenderer)panel).material.color = new Color(0.2683339f, 0.4018649f, 0.4245283f, 0.1f);
        }
            
        this.gameObject.SetActive(true);
    }
}
