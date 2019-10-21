using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCollector : ItemCollectorBase
{
    public SignStation station;
    public SolarPanel solarPanel;

    public override ItemTypes OnInteract()
    {
        containsItem = false;
        alert.SetActive(false);
        if (solarPanel != null) {
            solarPanel.setupTask();
        }
        if(station != null)
        {
            station.setAlert();
        }
        PlayInteractSound();
        return item;
    }


}
