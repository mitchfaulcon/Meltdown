using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : ItemCollectorBase
{
    public int waterLevel = 0;

    public new void fill()
    {
        //increase water level for if multiple tasks need water
        waterLevel++;
        containsItem = true;
        alert.SetActive(true);
    }

    public override ItemTypes OnInteract()
    {
        //when can contains no more water, remove alert
        waterLevel--;
        PlayInteractSound();
        if (waterLevel == 0)
        {
            alert.SetActive(false);
            containsItem = false;
        }
        return item;
    }

}
