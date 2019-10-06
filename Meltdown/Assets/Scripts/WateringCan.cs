using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : ItemCollectorBase
{
    public int waterLevel = 0;
      public new void fill()
    {
        waterLevel++;
        containsItem = true;
        alert.SetActive(true);
    }

    public override ItemTypes OnInteract()
    {
        waterLevel--;
        if(waterLevel == 0)
        {
            alert.SetActive(false);
            containsItem = false;
        }
        return item;
    }

}
