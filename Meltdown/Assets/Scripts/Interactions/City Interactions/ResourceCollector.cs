using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCollector : ItemCollectorBase
{
    public bool isSolarShop = false;
    public SolarPanel solarPanel;
    //All applicable method inherited from ItemCollectorBase
    public override void fill() {
        containsItem = true;
        if (isSolarShop) {
            solarPanel.setupTask();
        }
    }


}
