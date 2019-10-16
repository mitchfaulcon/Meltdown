using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaladItem : ItemCollectorBase
{
    public int quantity = 0;

    public override void fill()
    {
        quantity++;
        containsItem = true;
        alert.SetActive(true);
    }

    public override ItemTypes OnInteract()
    {
        playSound();
        quantity--;
        if(quantity == 0)
        {
            containsItem = false;
            alert.SetActive(false);
        }
        return item;
    }
}
